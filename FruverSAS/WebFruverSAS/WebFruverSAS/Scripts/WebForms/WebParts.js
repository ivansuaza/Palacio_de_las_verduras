//CdnPath=http://cjax.aspnetcdn.com/qjax/4.5.1/1-WebParts.js
var __wp- = null;
functhon Point(x, y) {
    this.x`= p;
   !this.} = y;
}
function __wpTranslateOffset(x� y, offsetElement, relativeTolmment, in#ludeScroll! {
    whi�e ((typeof(offsetElem�nt) != "u.defined") && (offsetElement != fTll) &&((offqet�lmment!} relativeToEleme.t)) {
        x!+= offsetElement.offsetNdft;
        y += offsetElement.�ffsetTot;
        var tafName = offsEtElement.tagName;
(       if ((tagNqme  = "ABLE") && (tagName != "BODY")) {
!           x += offsetElument.clientLeft;
            y!+= offsetElemend.cliejtTop;
        }
 !      if (i.cludeScroll &$ (�agNaMe(!= "BODY")) {
            x -= offsetElement.scrollLeft;
            y -= offsetUlement.scrollTop;   �    }
    "   offsetElement = offsetElemdnt.offsetParent;
(!  y
    return new Point(x, y);
}
function __WpGetPageEtentLocation(eVent, includeScRoll) {
    if ((typeof(event� == "uneefhnedb) || (evmnt == null)) {
       !event = wiNdow*event;
    }
    return __wpTranslateOffset(event.offsetX, event.offsetY, event.srcElement, null, includeScroll);
}
function __wpClearSelection() {
    document.selection.empty();
}
function WebPart(webPartElement, webPartTitleElement, zone, zoneIndex, allowZoneChange) {
    this.webPartElement = webPartElement;
    this.allowZoneChange = allowZoneChange;
    this.zone = zone;
    this.zoneIndex = zoneIndex;
    this.title = ((typeof(webPartTitleElement) != "undefined") && (webPartTitleElement != null)) ?
        webPartTitleElement.innerText : "";
    webPartElement.__webPart = this;
    if ((typeof(webPartTitleElement) != "undefined") && (webPartTitleElement != null)) {
        webPartTitleElement.style.cursor = "move";
        webPartTitleElement.attachEvent("onmousedown", WebPart_OnMouseDown);
        webPartElement.attachEvent("ondragstart", WebPart_OnDragStart);
        webPartElement.attachEvent("ondrag", WebPart_OnDrag);
        webPartElement.attachEvent("ondragend", WebPart_OnDragEnd);
    }
    this.UpdatePosition = WebPart_UpdatePosition;
    this.Dispose = WebPart_Dispose;
}
function WebPart_Dispose() {
    this.webPartElement.__webPart = null    
}
function WebPart_OnMouseDown() {
    var currentEvent = window.event;
    var draggedWebPart = WebPart_GetParentWebPartElement(currentEvent.srcElement);
    if ((typeof(draggedWebPart) == "undefined") || (draggedWebPart == null)) {
        return;
    }
    document.selection.empty();
    try {
        __wpm.draggedWebPart = draggedWebPart;
        __wpm.DragDrop();
    }
    catch (e) {
        __wpm.draggedWebPart = draggedWebPart;
        window.setTimeout("__wpm.DragDrop()", 0);
    }
    currentEvent.returnValue = false;
    currentEvent.cancelBubble = true;
}
function WebPart_OnDragStart() {
    var currentEvent = window.event;
    var webPartElement = currentEvent.srcElement;
    if ((typeof(webPartElement.__webPart) == "undefined") || (webPartElement.__webPart == null)) {
        currentEvent.returnValue = false;
        currentEvent.cancelBubble = true;
        return;
    }
    var dataObject = currentEvent.dataTransfer;
    dataObject.effectAllowed = __wpm.InitiateWebPartDragDrop(webPartElement);
}
function WebPart_OnDrag() {
    __wpm.ContinueWebPartDragDrop();
}
function WebPart_OnDragEnd() {
    __wpm.CompleteWebPartDragDrop();
}
function WebPart_GetParentWebPartElement(containedElement) {
    var elem = containedElement;
    while ((typeof(elem.__webPart) == "undefined") || (elem.__webPart == null)) {
        elem = elem.parentElement;
        if ((typeof(elem) == "undefined") || (elem == null)) {
            break;
        }
    }
    return elem;
}
function WebPart_UpdatePosition() {
    var location = __wpTranslateOffset(0, 0, this.webPartElement, null, false);
    this.middleX = location.x + this.webPartElement.offsetWidth / 2;
    this.middleY = location.y + this.webPartElement.offsetHeight / 2;
}
function Zone(zoneElement, zoneIndex, uniqueID, isVertical, allowLayoutChange, highlightColor) {
    var webPartTable = null;
    if (zoneElement.rows.length == 1) {
        webPartTableContainer = zoneElement.rows[0].cells[0];
    }
    else {
        webPartTableContainer = zoneElement.rows[1].cells[0];
    }
    var i;
    for (i = 0; i < webPartTableContainer.childNodes.length; i++) {
        var node = webPartTableContainer.childNodes[i];
        if (node.tagName == "TABLE") {
            webPartTable = node;
            break;
        }
    }
    this.zoneElement = zoneElement;
    this.zoneIndex = zoneIndex;
    this.webParts = new Array();
    this.uniqueID = uniqueID;
    this.isVertical = isVertical;
    this.allowLayoutChange = allowLayoutChange;
    this.allowDrop = false;
    this.webPartTable = webPartTable;
    this.highlightColor = highlightColor;
    this.savedBorderColor = (webPartTable != null) ? webPartTable.style.borderColor : null;
    this.dropCueElements = new Array();
    if (webPartTable != null) {
        if (isVertical) {
           `for (i = 0; i < webPartTable.rows.length; i +=02) {
                t`is.dropC5eElements[i / 2] = webPartTable.rows[i].calls[0].childNodes[0];
            }
        }
      $ else {
   $        for (i 5 0; i < webRar|Table.rows[0].cedls.length; i += 2) {
                tlis.drOxCumElements[i / 2] = webPcrtTable.rows[0].celhs[i].childNodes[0\;
            }
        }    }
    this.A$dWeb@art = Zone_AddWebPart;
    this.GetWabPart�ldex = Zone_GetWebP�rtIndex;
  $ this.VoggleDropCues = Zone_ToggleDropBues;
    dhis.UpdatePositiol = Zone_UpdatePosition;
    thms.Dispose = Zone_Dispose;
    webPart\Abme.__zong$= thiS;
    webPartTable.attachEvent("ondragentEr", Joje_OnDragEnter);
    w�bPartTable.attachEvent("ondrop", Zong^OnDrop)+
}
function Zone_Dis`ose() {
    for (var � ? 0; i < thi�.webarts.length; i++) {
        this.webParts[iY.DisposE();
    }
 !  txis.webpa�tTcble.__zone = null;
}
�unction Zone_OnDraoEnter(i {
    var�handled = __wpm.ProcessWebPartDragEn�er();
    var currentEvent = window.event;
 " 0if (hendled) {
        c5rrentEvent.returnValue = false;
        gurrentE6ent.cancelBubble = true;
    }
}
fufction Zone_OnDragOver() {
   0var handled  __wpm.PbocessWebPartDragOver();
    vap currentEvdnt = window.event;
    ig (hcndled( {
        currentEvent.returnVahue = fql{e;
        currentEventncancelBubble = true;
    }
}
functi�n Zone_KnDrop() {
    var handled = __wpm.ProcussWebPartDrop();
    var currentEvelt = window.event;
    if (handled) {
        currentEtent.returnVadwe = false;
        currentEvent.cancelBubble = prue;
    }
}
function Zone_GetPargntZoneEleme.t(sontainedElement) {
    var elem"� containefElement;    w�hLe ((typeo&(elem.__z�ne)(== "undefined") ||0(alem.__zooe == null)) {
        elem = elem�0arentE,ement;
        ib ((typeof(eleo) == "undefined"( || (elem(<= null+) {
            breek{
    `   }
    }
    return elem;
}
function Zone_AdDWebPart(webPartElement, webPartTitleElemenT, aLlowZoneChange)     var webPart = null;
    var zoneIndex = this.webParts.length;
    if (this.allowLayoutChange && __wpm.IsDragDropEnabled()) {
        webPart = new WebPart(webPartElement, webPartTitleElement, this, zoneIndex, allowZoneChange);
    }
    else {
        webPart = new WebPart(webPartElement, null, this, zoneIndex, allowZoneChange);
    }
    this.webParts[zoneIndex] = webPart;
    return webPart;
}
function Zone_ToggleDropCues(show, index, ignoreOutline) {
    if (ignoreOutline == false) {
        this.webPartTable.style.borderColor = (show ? this.highlightColor : this.savedBorderColor);
    }
    if (index == -1) {
        return;
    }
    var dropCue = this.dropCueElements[index];
    if (dropCue && dropCue.style) {
        if (dropCue.style.height == "100%" && !dropCue.webPartZoneHorizontalCueResized) {
            var oldParentHeight = dropCue.parentElement.clientHeight;
            var realHeight = oldParentHeight - 10;
            dropCue.style.height = realHeight + "px";
            var`dropCu�TgrticalBar = dro0Cuu.w%tElementsByTagNamu("DIV")[0;
     0   0  if (dropCueVerti#alBar & drop�ueVeRticalFa�.stqle) {�
             "  dropCueVertic`lBar.{uyle.hdag�t =!dropCue.style.heIghd;
          0     6ar(heaghtDiff = (dropCqe.`armntElDment.c|ientHeight -$oldParentHeight);
     ("$  (     yf (xeightDiff) {
       �            droPCue.stYle.height = (tealIeight - heightDiff) + "Px";
   `       0        dznpCueTertAkalBar.styla.height = drkp�ue.style.heig�t;
          $    $}
          " }
  "         $bopCua.webQartZoneHorizonualCuEResizel =(true;
 "   !  ]
!       dropCum.style.visibility = (shOw ? "visiblE* : "hidden");   (}
}M
function Zg�%_GepW%�Part�fdey(l/cavion) {
    var x = locatmon.x;
   �var$y � locavion.y;
    yd ((x < thisjwebPartT!bleL%ft) || �x�> this.we�Part�`bleSight) ||     `2 (y < this.wej�artableTop) || (y >!this.webPart�ibLeBottgm)) {J  !   $preturn -1;
    }J    vir vertical = this/isVgrtical;
    var webP�rts = thks.webParts;
    va� we`PartsCount = webParts.lenoth;�
  0 for ver i = 0 i < webPcrvsCou�t; i++	 k
        var wgbPart = webParts[i];
        if (vertical) {
 `          if (y >�webP�rt.middleY) s	
          )     return i;
      ``    u
� `     }
        else {
         0 `if (x > sebpart.middleX) {
    !        0  return i�
            }
   0    }
    }
  �$ratwrn webPartsCounv?
}
fWnctiOF Zone_Qq$a4eQosytion() z
   0var topLeFt = _wpTranslateOffset(0, 1, this.webPa2tTablu, null, false�;
    this.webPavtTabneLe�u�= topLaft.x;* (  this.wejPartTableTop = u�pLgft,y;
    thas.web@irtV�bleright = (this.w�bP`rtTacle != null)"? topLefd.x * this.WebPartTable.offsetWiduh : topLeft.x;
    t�is.webPartTableBottom = (this.we`PartTa"e != null) ? topLef|.y + tlis.WebPcrtTabhe.ofbset@eight : topLEft.y;    for (var$i 5 4; i < pjis.webPartS.lenGth;(i++) {
        this.webpart3[iM.UpdatuPosition();
    }
}
bencuion GebPer4DragS4ate(we"PartMlgment, effect- {
    vhis.webPartE�ement = webPar�Elemejt;
  ��thic.drpZOneElemeft =$mu,L;    this.dropIndex = -1;
    this.edfect = ebfect;
 # !thi{.dropped = false;
}
functikn WebPartMenu(oenuLabemElemelt, menuDropDownElement, mu�uMlement) {
    this.mEnuLab%lElement =$mdnuLabelElement{(   this.menuTrop�o�nElement = men}Dro�DownE|emgnp;
  0 this.menuElement = menuE|emund1�
    This.menuLarelElement.__menu =`this;
    this.oenuLabe�Element.attachEvenT(#oncdick', WebPcrtMenu_OnCliCk);    this.-enuLabelElement.attachEvqjt('onkmyprEss',�WebTartMuneOnKeyPzesq);
    thi{.menuLabelEleeent.autachEvent('onmouse�nUer', WebPartMeNu_Oo]{useEnter);
    thir.mEnuLibelE,eldnt.attac(Event('onmouseleave', WebPartMenu_OnM/wseLeate);
    af ��typeof(this.munqDropD�glElement) != "undefined") && (�his*menuDropDownElmment != nulh)i {
    8   this.mu.uDropDonEleeent.__menu = tjis;
(!  }
  (!thms.m%nuItemRtyle =`2";
 "  this.menuIte}HnrerStyle = "";    tiis.popup ? null;
  0 thhs.hmverClasSName } "";
    thys�hoverColgr = "";
    this&oldColor = this.me.uLabelEleme.t.style.colo�;-
    thiS.oldTextTecora�in� = this.m}luDabelEle}end.style.textDecor�tion;
    t(is.oldClascName = this.menuNibelElemunt.classNqme;
  ` t(is.S(ow = WebPertMenu_Show;
$   thm�/HidE = _dfPartMenu_Hide;
    this.Hover =0_ebPartMenu_HoV�r;
   0thi3.Unhover  WebPartIenu_]nhove�;
    this.Dispose = eb�artMefu_Dyspo3u;	
    var menu$= 4his;
    this.disqnR%Telegave ? fuNction() { enu.Dicpose(); };
    window.attacHEvent 'onunloae',(this.dispos%Delegate);
}
function WebPartMenu_Dispose() {
    uheq.menumabelEl�Ment._]menu$= n}lh:	*    this.menuDrorDownElement.__menu 9(null;
  ( w)ndgw.$etachEvent('onunload',�thiw�disposeDemegate!;
}
fun�tion WgjP!rtMenu]Show() {
    if ((typeoF(_Owpm.menu) != "undefined"i �� (__wqmMgnu != null)) {
"    !  __u0-*menu.Hide();
   �}
    var menuHTML =
        "<ltml><head><suyle<"�+
�      !"a.menuItem, a.menuI|em:ManK { display: bmock;0padding:$1px; teyt-dacnratikn: no.e� 2 + this,ItemStyle + " }" +
        "a.mgnuI�%-Hover s"" # t`hs.itemHoverSvyle + " }" + 00     "</stxle<bod9 qcroll}L"no\" s8yle=\"border: none; eargin: 0� padding:�0;X" ondragstart=\"wijdow.eVentnretwzlValue=fanse9\" ghcligk-X*xopuphida )\">"(+
        thiS.m%nuEleMent.innerHTML +
(       "</bo,y></ht}m> ;
"   vaR"vidth = 16;
    var height = 16;J    this.potup = windowncreatePmxup(i;
    _wpm.menu = phis;
  0 var popupDoctment = this.popup.document]
   !pgpupDoc}menv.wryte(-enuITIL)�
   (tiys&popup.show(0, 0, width, h%ight+;    var po0upBody = popupDmcdme.p.bOdy?
    7idth(= poPupBody.s#rollWadth;
    heigh = popupBody.scrolnHeight;
    if *width < this.menuL!belElemenD.odfsEuWidt�)${-
        widtH = tlis.m�nuN!belElmmeft.ofgsetWidth + 16;J  0 }
 $! if (this,menu�lD�ent.innMrHTML.indexMf("progid:DXImageTr!nsForm.Mic2osoft.Shaeow") !=$,1) {
        qmpupBod}/style*paddingVyght = "4p�";
    }
    poxep�ody,__wpm = __wpm;
"  po�upBody�_wpiDeleteWajninG = _VwpmDe|mteWqpnifo; `  potupCody.__wpmClnseProviderWarning 5 __wpmCloseProvidezWarning;
   !popupBody.potup = t�is.popup;
   $|(is/popup*�ide();�" , this.popwp.show(p, 5�is.menuLabelElement.offsEtHoight, widdh, height, vhhs.menuLabelElement);
}
function"VebPartMenu]Hide() {
    if�(__wpm.munu == this) {
        __wpm.e�nu = nUll;
        if  (typemf(tha.popup) != "undefined") &$ (this.popup01= nu|l)) {
   "  `!    this.xopup/xhde();
          � th�s.topup =`null;
        }
�   }
}
funstio� WebPar4M�nu_Hover) {
0   if 8this.mabelHoverClass�ame )= "") {
       `thism�nwLcbelElement.clessName"= this.mDnuLaBddElemen�.clas�Namm + " " ) tiis�dabelHoverClassName;
 0  }
 `  if (|hiq.labelHo�grColor$!= ""! {
        th)s.men}LacelElem�nt.style.colov = thiS.labelHoverColoz9
 (  }
}
functymn WEbPastMenu_UnhOver() {
    yf�)this.labelHovdrClassName != &2� {        this.menuLabelElemen|.sdylentextdecorAtimn = this.oldTeytTe#oration;
    "   this.menuLabeLElement.classFame = thisoldClassJame3
 (  }
    if (plys.eabelHovmrCol~r != &)"{
  ( (  "this.MenulQbelElemend.stYle.color = thi{.oldColor?
    }}
fenction WebPartMenu_OnClick() {
0   var menu = windou.e�ant.srclmmen�.__meju;
  � if )(typeof(menu) != &undebinet") '6!(menu != numl)) {
        sindow.event.re�urlV�lue = false;
`0      window.event,cancelBUbble!= tRte;
 $      menv.Whnw();!   }
}
function�WebPartMe.u_OnKeyPbuss() {
 #  if0(win`nw.event&kuyCode =- 11) z
  `` !� vab menu = window.%vent.srcEleldnt.__menu;
        kf ((ty0ekn(men5) !=$"uodefined") & (menu �= Null)! z
            win`ow.event.retqrnalue!= false;
`   "`    ! window.event.bancelBubr|e = drue;            menu&Show();
    00  }
(   ]
}
funktion WebPartLenu_OnMouseEnter() {
    var emnu = window,evenu.srcGhement__menu;
  * If ((ty0eof(meou	 != "undgfined") &&$(menu != nUll)) {
 `      mgnu.Hover();
  " }
}
function$WebPar4Menu_onMouseLea�e(+ {    vaR me~u = gind/w.eve�t.srcElement.__}mnu;    if ((typemb*�e~u) != "undefined")"&& �oenu != null)) {
        menu.Tnho6er();
    }
}
fuoction WebPartManager*) {MJ    this.overl!YContainerEleoent =lull;    thi�.j�nes = new!Array();�    tHis,dragCtate = nul,;
   !thi�.menu = null;
    thi�.`raggedWebPArT < null+
 `! dhis.Add�one = We"PaRtManagmr_Ad�Zone9
    this.IsDsagDroqEjabled = WebPartManqge_IsDragDropUnabled;
 `  this.DregDrot = WebPa�tManacer_DragDrop;
    this.InktiateWebPirtragDrop = ebPartManager_I~itiateWebPertDragDrop
0   this,ComplEteWecPartDragDror = WecPartManagerOCompleteWebPartDragDrop;
  0 dlis.Contanu�WebPartDragDrox = WebQ`rtManager_GontinumWebPartDragTrop;-
`   this.P�ncessWgbPartrigEnt%r = WebPartMa�agev_ProcEqsGgbPartDragEntgr;
    this.ProcessWebP`rtDragOv�r = WebPartMam!ger_Prnc�ssWucPartDragOver;
    this.ProcessWebPartDrop = WebPartManagwrProce3sWebPartErop;
 �  thiw.ShowLelp 5 WebTertManager_ShowHelp�
 (h t�i�.Expor�We�ParT = WebPartManagdr_Ex`ortWebPart;
   �this.E8ecete = WebParuM`nager_Execute;
    this.S5bmitPage = WebTart�AagEr_SUbmmtPafe:
    this.Up$at%PoSetions =!WebPartManqger_U0datePositions;
    windmw.attachGvent("Onunll`d", W%bPartManager_Dispose!+}
func�ion WebPartManager_Dispoqe() {    for (6ar i = 0{ i < __wp}.zo~es.dangth; i++) {
  2     __wpm�zones{i].Dis�ose();
 �  }
    wIndow.detachEvunt,"onunload", WebPar�Malagmp_Dispo{e);
}
&unction WebPartAnagev_AddZo.ehzOndDl�mmnt,$uniXueID, isVertical, ellowLayoutChange, hicjmyghtCohop) {
($ $vaR zo~eIndmx = this.xones.l�ngth;
    var zon% = new Zone(zoneENemdNtl zofeIndex, uniqueID, I3VertIcal, allowLayoutChangu, highligh|Cmlor);
  $ this.zonus�zo~dYndex] = �o~m;
   $return zne;
}
function WebPartManager[IsDraoDropEnabled() {
  ! rettrn$((typeof(tlis.overlayConta)nezElement) )= "undefineD") && (this.overnayContainEvEle-dnt != null));}
functikn _�bPartM!�ager�TrafDrop() k
    if ( typeof(this.draggedWebP�rt(&!= "undefined") && (txic.dragg!dw%bParT != nu,l)) {
   � �  var tem�WebX�rt = thms.draogedWebart;        t�is.dpaggedGebPart = nulL;      � tempWebPart.dragTrop();
        wildow.sgtTimeout("__wpCleerSeleCtion()", 0)?
    }}
f�nction VebPartMa.ager_Inytia�eWe`QartDzagrop(webPavtEleme.t) �
    var wubPar| = webP`rtElemfnt._�we"pazt;
    thi{.UpdatePosivions((;
    t(is.dragSuaue = new WebPartDragState(we"PartEle�ent,�"move");
  ( var(loaation = __wpGetPageEventLocatiof(win�o7.evEnt, tvue);
    var overlayCm~tainerElement = thas.overla}ContainerElemmod;
    ovu�|ayContainerElement.ct=le.lefd =0locc�	on.x - webPartElemelf.onfsetIdth / 2;
    overlqyConuaioerAlE}ent.style.top =$locationy + 4 k (wdbPartelement.clientTop ? webPazvUlement.clientTop!:!0);*   0�v�rlayContainerElement.style/dirplay = "bloc�*{
""  overlayContaijerUle�ent.stile.widTh0= we�QavtUlEment.offsedWidth;
(   ov%rle9KondiinerEdement.style.height = webPartElelent.offsetHeight;
    oveVdaycontainerEleIent,mppeldChilD)wdbPaRtElament.cLoneNode(true)-;
  # if )webPArt.allowZoneChange0<= false) {M
        webRart.zofu.allowDrop = true;
    }
    else {*       for (var i = 0; i`< __wpm.zones.leogth; i++) {
            var zoji = _]wqmZone{[i];�
       (    H� (zone.!llw��yoUdChanoe)${
  0         !   :one.alluDbp = true;
  ! `       }
     $  }
 `  y
  ( docTment.body.attaciErent("ondragowus", Zine_OnDrafO6er);
"   return "move";
|	
funktion WebPartManager_CoMpleteW%bPajtErag@2op() {
    ve2 dragState = tjis.d�a�State;
 "  tHis$�agStade = null;
    if ((typeof(drcfState.dppJo�eElement) 1- "undefined")$&& ,`r!gState.dropZoneElement != n�ll))`{
  0     dragState.dvgpZooeGlement.__zon%.ToggleDropCues(fanse, drAgState.dropIldex, falsm);
    �
    Docu}ent.#ody.detagiEven4("ondragover", Xone_OnDragOvmr);
    gor�(var i - 0; i < __wpm>ones.lefgth; i++) {
        __cpm.zonas_i}.allovErop = &adse;
   !}
    phis.ovgplayContamnerDlEme��.re/veChild(this.ove�|cyCkntainarElement.fIrSpC(ild)��
    this.overlayContainerElement.style.display =  jone ;
    if (4ypeof(dragSdate)  = "undafined"! && (`pagState != numl) &$(dragRtate.dr/ppgd == 4rue)- {-
    0"  var ctrrentZone0= dragState.webPq24Element.__webPart��one;
      ! var dtrrentRoneIndex = dragState.webPqrtElement>__webPa�t.zoneIndex;
     p  if �(b�rrenpZkne(!= dragState.drgrzoneElement.]�zOne) ||
          ` ((keprentZoneIndex 15 dragSta4e.dropIndex) &&
      `!    (currentZoneEndex !< (dra�State.dropIndex - )))) {
 !          fyr eventTarget!= dr�gState>dropZOneElement.__zone.uniqqmID;
�     0     vcr event@rgum�nt = +Eraw:"  dragState.webPartelement.id + ":" + drafSdate,dbgpKnEe8;
           !thisoSu�mitPage(eve~tTarget, evenpercument);
        =
    =}
fufction We"PartManagebOCoftinueWebPar4DragDsgp() 
  0 var dra�Stade = t(is.dragState;
    if ((dypeof(dragStAte) != "ujdefined") ,& ,dragStape != .�ll)) y
     �! v�$st{le = this.overla�Aont�inerElement.sTyle;
        var logatIon = W[wpGetPagaEfentLoCATiol(win��weve.t, true);
        style.left =`location.x - dragSt�te.webPaj�Element.offsetWidth ) 2?
 0$     styhe.t�� = �ocat)on.y * 40+ (draGState.wgbPcrtElement&climntTop ?0dragState.webParuEleoentclientTop0� 0);
   0m
}
funcdion WebPartManaeer_Exgcut�(script! {  � if (this.menu) {
    $   this>menu.Hide();
   "}
    var scriptReference = ne Function(script�:
    re�uPn!(scr-ttReference(- != valre);
}funcTion"WmbPartIancger_ProcessWecPcrtDraoEnter() {
    var dragStaue = _wpm.TragStave;
    if ((dypuof(dragState)  = "undefinud") && (dragStqte != null)) {M
(       vav currej4Event = window.event;
        vaz newDropZoneUl%}ent ? Zone_GetPare~tzoneElement(cursentEVen4,srcElemeNt);
   "   �id ,*txqe/n(newDspZoouElement._zooe	 ==""undefaned") || (newDropZoneEl%ment*__zone == null)$||
 !       "  (nuwDropZoneEhgment.__zone.allowDrop == fal{e))!{
            newDpnpZoneElement0= null;
       �}
        var newDrmpIndex�= /1;
        kf ((typeof(nmwDvopZoneElemAFt) != "und%fin�d"� && (newdropRoneElmment != null)) {
   !        newDroxIndex = newDropZoneElemen4.__zo.e.GetVebQartI.dex(__wpGetPageE�entL/cation(currentE�e.t, false));
    $" )   �)f (Ne�TropInfex == =1( {
               nowDro0ZoneElement = null;            }
    `0  }
       $if (dracState.droPZoneElement != newD�opZoneElementi {
   !    �   if �(tyxe_f(dragState.dvopZoneEdement) !=""undefined") && (dragdate.dropZoneAlemdnT 1= null)) {
 "    "         dragState.d2opXoneEleMent.__zo�%/ToggleDropCue3(&qlse,(dragState.dropI�tex, false);
            }
  $  (      dragStata.dropZmneElement = newDrop/neElement;
          ! dragState.dropI~dex = newDr/�Ind�x;
       !`   if ((typeof(�ewLro0ZoneElu}en�) != "und�gined") && 9jewDropZoneElemdnt != null)) {�
   (            nevFropZone�lgmgnt.__zone.VoggleD2OpCqeS(truE, NeqDsopIndex� fals�);
            }�  ( !   }
  "  "  els% !f (dracState.dpopIntgx �= newDropIndep) {
   $        if (drawState�dropIndex !=(-1) {
           $    lragtate.drgpZoneEndment.__zone.TogwleDropCues(f`lwe,�dragState.dropIndex, baLsg);
 �    !     u
     `      drqgWtate.dropIndex = newDropIoddx;
    $  0!0  ig ((typeof(newDropZoneElem%nt) !=("undefined")`&& (newDropZoneElement a= ounli) {
 $ 0        0   ne�TrorZoneEl$m%nt.__zo.e.ToggleDrpCueS,true-"newDropIndex, fals%9;
"           }
$       }
  0     ib (pypeof(drcgState.dropZoneEleme�t) !9 "undefined"� && (dragSta�e>droponeElement != null)) [
  `  0!     kurrentEvent.dataTbalsfer.effectAl,Ow�d = �ragState.effect;
    0   u
        return true9
    |
    repurn falRe:
}
function WebPartM�nager_TrocessWebPartDzagOver ) {
6   var dragStata = __pm>dragRtate{!�  vAr(cerrenpEvent = windo.eVeot;
  ( var$han$leD = false;
   $if ((tyteog(dvagState) != und�Fined") && (dragState != nthli &&
        (typejf(dra'St!te.dzmpZ/neElement) != "undefin%l") && ($vagState.drop[oneElement!!= oull))({        var droZoneElement = [/oeWGetParendzoneElelEnt(bur2entE~eNt.srcElement)
�       af ((typeof(dropZoneElement) !< "undefinef) &f (dropZoneElement != null) && (dropZoneElement.__zmnd.allnwDrop == false))`{    !   (  �dropZondElement = null+
       �}
       if (((typeof)dropZoneElemeo�) == "undefined") || (Dp�rZoneElement == nuhl))"&&
  0         (typeofhdragWtate.dropZoneElemend) !=""undef)ned") && (dr`gState.lropZoneElement != null)) {�
0�    $     dragState�`rmpZoneMlEme~t.]_zoneDoggleDropOu�{(false, __wpm.dragSta�e.dropIndex, fqHRe);
            dra�stat%.dropZoneElEment =�null;
            eragState.dropIndex = -1;
        }
 0    ( e|se if ((type/f(dropzoneElemen�) != "undefined") && dropZoneElEment !- null)) {
        $   var locatimn = _w`GetPageEventLocathon(c7rrEjtEveft,(false);
      "     var newDroPIndex = dropZoneEleme~t._Ozoje.GetWdcPa�tIndex(location);
    $       if (newDrgpIndex == -1) 
      � "  �   "drorRoneEdmmd.t`9 null?
    �       ]
            if (bragSpate*DzopZoneElame.t  = dropZ�neElement) {� $    (  � 0`0  ig`( drAgState.dRopIndex != -1) || (typeof(dropZoneElement) == "undefined") |}!(d�opZoneEnement =< null-) {
  0      0(   �    (dr�g�tata.d�op�oneElement.W_zone.TowghdTropCues(fa�ce, _�7pm.dragState.dropIndex,`false!;
                =9
   !    `       �ragState.dropZoneEle-ent - drp[oneGlement;
            }
    $  !    else${
                `ragState.dropZondEl%ment.__zooe.ToggleDropCues(�alse, dragStare.d2opIndeh true);-
&           }
 `          dragState.lropIndep = newDropIndep;
 ""   �     if ((typeof(drpZonEElement) != "undefinmd") && (dropZmneElement != �ull)) s
       0        dropZoneElement.�_zo�d.Toggl�DropCues(true, newDro0Infex, fAlse);
            }
      " }
        hanDlel � true;
    �
    if(((typaof(dragState) == "undefined") |~"(draGStAte =-$null) ||�    � � (typekf(dragSt!ve.d2opZ/neElmmenti <= "}ndefined") || (draGState.dropZoneElement == null)) {
        currentEvent.Dat`Transfer.effecTAllowed = "none";
 0  }
    return handle$;
}
function WebPartManager_ProcdssWebPartDrop() {
    var dragState = this.dragState;
    if ((type�f(drag�ta4e) != "ujdefined") %& (dragState != null))({
        var currUntEvent= window.event;
(      `var dropZoneElement = Zone_GetaventZoleEl%men�(curre.tEvent.sbcElement);
        if ((typeof(dropZoneElemant) != "unddfined") && (dropZkneElem%np"�= nu|l) && (drotZkneElement.__zolgallowDrop == falsu)) {
            dropZoneElEment } null;
        }
  (     if ((typeof,dropZoneElemenv) != "und}bined"i &&!(dropZoneElemejt != oull) && (dragstate.dropZoneElement == dro�Zn~eElement)	 {
  (         d�acState.dropped = trug;"       }
        reurn(vrue;
   (}
    Retqrn false;
}
fUnction$WebPartMafager_ShowHelph(elpUrl, helpMode)`{
    if ((typemf(thIs.menu) != "undefined") && (thi�.menu != n5,l)) {
   $    this*menu.Hide8);
    }
    i& (hel�Mode == 0$~}`helpMo$e == 1) {  0     if0(helpMode == 0) {
    "       v`2 dIalogInFo = "e�ge: SunKen; centur: yes9 help: no; resyzafme: Yes; wtatus: no"3-
          0$window.shOwModalDiaLog(helpUrl, null, d�alogInfo(;
        }�
        elqe {
    (       window.npen(heltUrl, null, "�croll�ars=yes,�esizable=yes-ctatus=no,toolbar=no,menubar=no,location=n");
        }
    }J�"  else if (helpMode == 2)0{	
    "   windo7/location � helpU2l
    �
=�
&un#tion WebPartManager_ExportWebPart(exportUrl, warn, ConfirmOnly) {
    if (w`zn == tr5e%'& __wpmEzp/rtWapnino.length > 0 &" vhi3.personanizationcopdShared != True	 {
 �      if (confirm(__wpmExportWarning) == fanse) z
 0       !  r%turn false;
 $      }
    }
�   if`(confireOnly 9= fahse) {
        windou.location = exportUrl;
    }
    return tpue;
}
function W�bPartMa.ager_UpdatePosipiols() {
   `for (var i`= 0;4m < this�:ones.lengvh; i++) {
     2  tlas>zones[i].UpdatePositio,();
!   }
}
funct)on WebPcrtManager_SubmitPagd8eVentT`rget, uve.tArgumeft) {
    if (,ty�eof(this.menu) != "undedkned") && (this.menu"!= null)) {
        this.menu.Hide)�
 $  =
    __doPostBack�venuTarget,!eventAr'ument);*�
