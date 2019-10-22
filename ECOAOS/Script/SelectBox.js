
      
      var arrHandle = new Array();
      //Listing 10.6
      function SetProperties(xElem,xHidden,xserverCode,
        xignoreCase,xmatchAnywhere,xmatchTextBoxWidth,
        xshowNoMatchMessage,xnoMatchingDataMessage,xuseTimeout,
        xtheVisibleTime){
          var props={
            elem: xElem,
            hidden: xHidden,
            serverCode: xserverCode,
            regExFlags: ( (xignoreCase) ? "i" : "" ),
            regExAny: ( (xmatchAnywhere) ? "" : "^" ),
            matchAnywhere: xmatchAnywhere,
            matchTextBoxWidth: xmatchTextBoxWidth,
            theVisibleTime: xtheVisibleTime,
            showNoMatchMessage: xshowNoMatchMessage,
            noMatchingDataMessage: xnoMatchingDataMessage,
            useTimeout: xuseTimeout
          };
          AddHandler(xElem);
          return props;
      }

      //Listing  10.8
      var isOpera=(navigator.userAgent.toLowerCase().indexOf("opera")!= -1);
      function AddHandler(objText){
        objText.onkeyup = GiveOptions;
        objText.onblur = function(){
          if(this.obj.useTimeout)StartTimeout();
        }
        if(isOpera)objText.onkeypress = GiveOptions;
      }

      //Listing 10.9
      var arrOptions = new Array();
      var strLastValue = "";
      var bMadeRequest;
      var theTextBox;
      var objLastActive;
      var currentValueSelected = -1;
      var bNoResults = false;
      var isTiming = false;

      //Listing 10.10
      function GiveOptions(e){
        var intKey = -1;
        if(window.event){
          intKey = event.keyCode;
          theTextBox = event.srcElement;
        }
        else{
          intKey = e.which;
          theTextBox = e.target;
        }
        if(theTextBox.obj.useTimeout){
          if(isTiming)EraseTimeout();
          StartTimeout();
        }
        if(theTextBox.value.length == 0 && !isOpera){
          arrOptions = new Array();
          HideTheBox();
          strLastValue = "";
          return false;
        }
        if(objLastActive == theTextBox){
          if(intKey == 13){
            GrabHighlighted();
            theTextBox.blur();
            return false;
          }
          else if(intKey == 38){
            MoveHighlight(-1);
            return false;
          }
          else if(intKey == 40){
            MoveHighlight(1);
            return false;
          }
          else{}
        }
        if(objLastActive != theTextBox ||
           theTextBox.value.indexOf(strLastValue) != 0 ||
           ((arrOptions.length==0 || arrOptions.length==15 ) && !bNoResults) ||
           (theTextBox.value.length <= strLastValue.length)){
             objLastActive = theTextBox;
             bMadeRequest = true
             TypeAhead(theTextBox.value)
        }
        else if(!bMadeRequest){
          BuildList(theTextBox.value);
        }
        strLastValue = theTextBox.value;
         // document.getElementById("ddlBarchAudit").style.display = "none";
         // document.getElementById("ddlDeferment").style.display = "none";
          hideLayerEvent(arrHandle);
          
      }

      //Listing 10.11
      function TypeAhead(xStrText){
        var strParams = "q=" + xStrText +
                        "&where=" + theTextBox.obj.matchAnywhere;
        var loader1 = new net.ContentLoader(theTextBox.obj.serverCode,
                                            BuildChoices,null,"POST",strParams);
      }

      //Listing 10.12
      function BuildChoices(){
        var strText = this.req.responseText;
        eval(strText);
        BuildList(strLastValue);
        bMadeRequest = false;
      }

      //Listing 10.13
      function BuildList(theText){
        SetElementPosition(theTextBox);
        var theMatches = MakeMatches(theText);
        theMatches = theMatches.join().replace(/\,/gi,"");
        if(theMatches.length > 0){
          document.getElementById("spanOutput")
            .innerHTML = theMatches;
          document.getElementById(
            "OptionsList_0").className=
            "spanHighElement";
          currentValueSelected = 0;
          bNoResults = false;
        }
        else{
          currentValueSelected = -1;
          bNoResults = true;
          if(theTextBox.obj.showNoMatchMessage)
            document.getElementById(
              "spanOutput").innerHTML =
              "<span class='noMatchData'>" +
              theTextBox.obj
              .noMatchingDataMessage +
              "</span>";
          else HideTheBox();
        }
      }

      //Listing 10.14
      function SetElementPosition(theTextBoxInt){
        var selectedPosX = 0;
        var selectedPosY = 0;
        var theElement = theTextBoxInt;
        if (!theElement) return;
        var theElemHeight = theElement.offsetHeight;
        var theElemWidth = theElement.offsetWidth;
        while(theElement != null){
          selectedPosX += theElement.offsetLeft;
          selectedPosY += theElement.offsetTop;
          theElement = theElement.offsetParent;
        }
        xPosElement = document.getElementById("spanOutput");
        xPosElement.style.left = selectedPosX;
        if(theTextBoxInt.obj.matchTextBoxWidth)
          xPosElement.style.width = theElemWidth;
        xPosElement.style.top = selectedPosY + theElemHeight
        xPosElement.style.display = "block";
        if(theTextBoxInt.obj.useTimeout){
          xPosElement.onmouseout = StartTimeout;
          xPosElement.onmouseover = EraseTimeout;
        }
        else{
          xPosElement.onmouseout = null;
          xPosElement.onmouseover = null;
        }
      }

      //Listing 10.15
      var countForId = 0;
      function MakeMatches(xCompareStr){
        countForId = 0;
        var matchArray = new Array();
        var regExp = new RegExp(theTextBox.obj.regExAny +
          xCompareStr,theTextBox.obj.regExFlags);
        for(i=0;i<arrOptions.length;i++){
          var theMatch = arrOptions[i][0].match(regExp);
          if(theMatch){
            matchArray[matchArray.length]=
              CreateUnderline(arrOptions[i][0],
              xCompareStr,i);
          }
        }
        return matchArray;
      }


      //Listing 10.16
      var undeStart = "<span class='spanMatchText'>";
      var undeEnd = "</span>";
      var selectSpanStart = "<span style='width:100%;display:block;' class='spanNormalElement' onmouseover='SetHighColor(this)' ";
      var selectSpanEnd ="</span>";
      function CreateUnderline(xStr,xTextMatch,xVal){
        selectSpanMid = "onclick='SetText(" + xVal + ")'" +
          "id='OptionsList_" +
          countForId + "' theArrayNumber='"+ xVal +"'>";
        var regExp = new RegExp(theTextBox.obj.regExAny +
        xTextMatch,theTextBox.obj.regExFlags);
        var aStart = xStr.search(regExp);
        var matchedText = xStr.substring(aStart,
          aStart + xTextMatch.length);
        countForId++;
        return selectSpanStart + selectSpanMid +
          xStr.replace(regExp,undeStart +
          matchedText + undeEnd) + selectSpanEnd;
      }

      //Listing 10.17
      function MoveHighlight(xDir){
        if(currentValueSelected >= 0){
          newValue = parseInt(currentValueSelected) + parseInt(xDir);
          if(newValue > -1 && newValue < countForId){
            currentValueSelected = newValue;
            SetHighColor (null);
          }
        }
      }
      function SetHighColor(theTextBox){
        if(theTextBox){
          currentValueSelected =
          theTextBox.id.slice(theTextBox.id.indexOf("_")+1,
          theTextBox.id.length);
        }
        for(i = 0; i < countForId; i++){
          document.getElementById('OptionsList_' + i).className =
            'spanNormalElement';
        }
        document.getElementById('OptionsList_' +
          currentValueSelected).className = 'spanHighElement';
      }

      //Listing 10.18
      function SetText(xVal){
        theTextBox.value = arrOptions[xVal][0]; //set text value
        theTextBox.obj.hidden.value = arrOptions[xVal][1];
        document.getElementById("spanOutput").style.display = "none";
        currentValueSelected = -1; //remove the selected index
        showLayerEvent(arrHandle);
      }
      function GrabHighlighted(){
        if(currentValueSelected >= 0){
          xVal = document.getElementById("OptionsList_" +
          currentValueSelected).getAttribute("theArrayNumber");
          SetText(xVal);
          HideTheBox();
        }
      }
      function HideTheBox(){
        document.getElementById("spanOutput").style.display = "none";
        //document.getElementById("ddlBarchAudit").style.display = "";
        //document.getElementById("ddlDeferment").style.display = "";
        if (theTextBox.value=="")
		{
		    theTextBox.obj.hidden.value="";

		
		      bNoResults = false;

		//document.getElementById("hidden1").value = "";
		}
        showLayerEvent(arrHandle);
        currentValueSelected = -1;
        EraseTimeout();
      }

      //Listing 10.19
      function EraseTimeout(){
        clearTimeout(isTiming);
        isTiming = false;
      }
      function StartTimeout(){
        isTiming = setTimeout("HideTheBox()",
        theTextBox.obj.theVisibleTime);
      }
      
      //事件
      var showLayerEvent=function(obj)
      {
          
          for (var i=0;i<obj.length;i++)
          {
             document.getElementById(obj[i]).style.display = "";
          }
      }
      

      
      //事件
      var hideLayerEvent = function(obj)
      {
          for (var i=0;i<obj.length;i++)
          {
             document.getElementById(obj[i]).style.display = "none";
          }
      }
      
      
      //事件委托
      var addShowHandle = function(obj)
      {
           arrHandle.splice(0,0,obj);
      }
      
      

      