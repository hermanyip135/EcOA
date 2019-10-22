
/*****************************************************************************
                                   ����ƫ���趨
*****************************************************************************/

var conWeekend = 3;  // ��ĩ��ɫ��ʾ: 1=��ɫ, 2=��ɫ, 3=��ɫ, 4=������


/*****************************************************************************
                                   ��������
*****************************************************************************/

var lunarInfo=new Array(
0x4bd8,0x4ae0,0xa570,0x54d5,0xd260,0xd950,0x5554,0x56af,0x9ad0,0x55d2,
0x4ae0,0xa5b6,0xa4d0,0xd250,0xd295,0xb54f,0xd6a0,0xada2,0x95b0,0x4977,
0x497f,0xa4b0,0xb4b5,0x6a50,0x6d40,0xab54,0x2b6f,0x9570,0x52f2,0x4970,
0x6566,0xd4a0,0xea50,0x6a95,0x5adf,0x2b60,0x86e3,0x92ef,0xc8d7,0xc95f,
0xd4a0,0xd8a6,0xb55f,0x56a0,0xa5b4,0x25df,0x92d0,0xd2b2,0xa950,0xb557,
0x6ca0,0xb550,0x5355,0x4daf,0xa5b0,0x4573,0x52bf,0xa9a8,0xe950,0x6aa0,
0xaea6,0xab50,0x4b60,0xaae4,0xa570,0x5260,0xf263,0xd950,0x5b57,0x56a0,
0x96d0,0x4dd5,0x4ad0,0xa4d0,0xd4d4,0xd250,0xd558,0xb540,0xb6a0,0x95a6,
0x95bf,0x49b0,0xa974,0xa4b0,0xb27a,0x6a50,0x6d40,0xaf46,0xab60,0x9570,
0x4af5,0x4970,0x64b0,0x74a3,0xea50,0x6b58,0x5ac0,0xab60,0x96d5,0x92e0,
0xc960,0xd954,0xd4a0,0xda50,0x7552,0x56a0,0xabb7,0x25d0,0x92d0,0xcab5,
0xa950,0xb4a0,0xbaa4,0xad50,0x55d9,0x4ba0,0xa5b0,0x5176,0x52bf,0xa930,
0x7954,0x6aa0,0xad50,0x5b52,0x4b60,0xa6e6,0xa4e0,0xd260,0xea65,0xd530,
0x5aa0,0x76a3,0x96d0,0x4afb,0x4ad0,0xa4d0,0xd0b6,0xd25f,0xd520,0xdd45,
0xb5a0,0x56d0,0x55b2,0x49b0,0xa577,0xa4b0,0xaa50,0xb255,0x6d2f,0xada0,
0x4b63,0x937f,0x49f8,0x4970,0x64b0,0x68a6,0xea5f,0x6b20,0xa6c4,0xaaef,
0x92e0,0xd2e3,0xc960,0xd557,0xd4a0,0xda50,0x5d55,0x56a0,0xa6d0,0x55d4,
0x52d0,0xa9b8,0xa950,0xb4a0,0xb6a6,0xad50,0x55a0,0xaba4,0xa5b0,0x52b0,
0xb273,0x6930,0x7337,0x6aa0,0xad50,0x4b55,0x4b6f,0xa570,0x54e4,0xd260,
0xe968,0xd520,0xdaa0,0x6aa6,0x56df,0x4ae0,0xa9d4,0xa4d0,0xd150,0xf252,
0xd520);

var solarMonth=new Array(31,28,31,30,31,30,31,31,30,31,30,31);
var Gan=new Array("��","��","��","��","��","��","��","��","��","��");
var Zhi=new Array("��","��","��","î","��","��","��","δ","��","��","��","��");
var Animals=new Array("��","ţ","��","��","��","��","��","��","��","��","��","��");
var solarTerm = new Array("С��","��","����","��ˮ","����","����","����","����","����","С��","â��","����","С��","����","����","����","��¶","���","��¶","˪��","����","Сѩ","��ѩ","����");
var sTermInfo = new Array(0,21208,42467,63836,85337,107014,128867,150921,173149,195551,218072,240693,263343,285989,308563,331033,353350,375494,397447,419210,440795,462224,483532,504758);
var nStr1 = new Array('��','һ','��','��','��','��','��','��','��','��','ʮ');
var nStr2 = new Array('��','ʮ','إ','ئ','��');
var monthName = new Array("JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC");

//�������� *��ʾ�ż���
var sFtv = new Array(
"0101*����Ԫ��",
"0202 ����ʪ����",
"0207 ������Ԯ�Ϸ���",
"0210 ���������",
"0214 ���˽�",
"0301 ���ʺ�����",
"0303 ȫ��������",
"0308 ���ʸ�Ů��",
"0312 ֲ���� ����ɽ����������",
"0314 ���ʾ�����",
"0315 ����������Ȩ����",
"0317 �й���ҽ�� ���ʺ�����",
"0321 ����ɭ���� �����������ӹ�����",
"0321 ���������",
"0322 ����ˮ��",
"0323 ����������",
"0324 ������ν�˲���",
"0325 ȫ����Сѧ����ȫ������",
"0330 ����˹̹������",
"0401 ���˽� ȫ�����������˶���(����) ˰��������(����)",
"0407 ����������",
"0422 ���������",
"0423 ����ͼ��Ͱ�Ȩ��",
"0424 �Ƿ����Ź�������",
"0501 �����Ͷ���",
"0504 �й����������",
"0505 ��ȱ����������",
"0508 �����ʮ����",
"0512 ���ʻ�ʿ��",
"0515 ���ʼ�ͥ��",
"0517 ���������",
"0518 ���ʲ������",
"0520 ȫ��ѧ��Ӫ����",
"0523 ����ţ����",
"0531 ����������", 
"0601 ���ʶ�ͯ��",
"0605 ���绷����",
"0606 ȫ��������",
"0617 ���λ�Į���͸ɺ���",
"0623 ���ʰ���ƥ����",
"0625 ȫ��������",
"0626 ���ʷ���Ʒ��",
"0701 �й������������� ���罨����",
"0702 �������������� ��Ʒ�ƽ�վ(http://www.21softs.com/)��ʽ���⿪�ż�����",
"0707 �й�������ս��������",
"0711 �����˿���",
"0730 ���޸�Ů��",
"0801 �й�������",
"0808 �й����ӽ�(�ְֽ�)",
"0815 �ձ���ʽ����������Ͷ����",
"0908 ����ɨä�� �������Ź�������",
"0910 ��ʦ��",
"0914 ������������",
"0916 ���ʳ����㱣����",
"0918 �š�һ���±������",
"0920 ���ʰ�����",
"0927 ����������",
"1001*����� ���������� �������˽�",
"1001 ����������",
"1002 ���ʺ�ƽ���������ɶ�����",
"1004 ���綯����",
"1008 ȫ����Ѫѹ��",
"1008 �����Ӿ���",
"1009 ���������� ���������",
"1010 �������������� ���羫��������",
"1013 ���籣���� ���ʽ�ʦ��",
"1014 �����׼��",
"1015 ����ä�˽�(�����Ƚ�)",
"1016 ������ʳ��",
"1017 ��������ƶ����",
"1022 ���紫ͳҽҩ��",
"1024 ���Ϲ��� ���緢չ��Ϣ��",
"1031 �����ڼ���",
"1107 ʮ������������������",
"1108 �й�������",
"1109 ȫ��������ȫ����������",
"1110 ���������",
"1111 ���ʿ�ѧ���ƽ��(����������һ��)",
"1112 ����ɽ����������",
"1114 ����������",
"1117 ���ʴ�ѧ���� ����ѧ����",
"1121 �����ʺ��� ���������",
"1129 ������Ԯ����˹̹���������",
"1201 ���簬�̲���",
"1203 ����м�����",
"1205 ���ʾ��ú���ᷢչ־Ը��Ա��",
"1208 ���ʶ�ͯ������",
"1209 ����������",
"1210 ������Ȩ��",
"1212 �����±������",
"1213 �Ͼ�����ɱ(1937��)�����գ�����Ѫ��ʷ��",
"1221 ����������",
"1224 ƽ��ҹ",
"1225 ʥ����",
"1229 ���������������");

//ĳ�µĵڼ������ڼ��� 5,6,7,8 ��ʾ������ 1,2,3,4 �����ڼ�
var wFtv = new Array(
"0110 ������",
"0150 ���������", //һ�µ����һ�������գ��µ�����һ�������գ�
"0520 ����ĸ�׽�",
"0530 ȫ��������",
"0630 ���׽�",
"0911 �Ͷ���",
"0932 ���ʺ�ƽ��",
"0940 �������˽� �����ͯ��",
"0950 ���纣����",
"1011 ����ס����",
"1013 ���ʼ�����Ȼ�ֺ���(������)",
"1144 �ж���");

//ũ������
var lFtv = new Array(
"0101*����",
"0115 Ԫ����",
"0202 ��̧ͷ��",
"0323 �������� (����ʥĸ����)",
"0505 �����",
"0707 �����й����˽�",
"0815 �����",
"0909 ������",
"1208 ���˽�",
"1223 ���˽�",
"0100*��Ϧ");


/*****************************************************************************
                                      ���ڼ���
*****************************************************************************/

//====================================== ����ũ�� y���������
function lYearDays(y) {
 var i, sum = 348;
 for(i=0x8000; i>0x8; i>>=1) sum += (lunarInfo[y-1900] & i)? 1: 0;
 return(sum+leapDays(y));
}

//====================================== ����ũ�� y�����µ�����
function leapDays(y) {
 if(leapMonth(y)) return( (lunarInfo[y-1899]&0xf)==0xf? 30: 29);
 else return(0);
}

//====================================== ����ũ�� y�����ĸ��� 1-12 , û�򷵻� 0
function leapMonth(y) {
 var lm = lunarInfo[y-1900] & 0xf;
 return(lm==0xf?0:lm);
}

//====================================== ����ũ�� y��m�µ�������
function monthDays(y,m) {
 return( (lunarInfo[y-1900] & (0x10000>>m))? 30: 29 );
}


//====================================== ���ũ��, �������ڿؼ�, ����ũ�����ڿؼ�
//                                       �ÿؼ������� .year .month .day .isLeap
function Lunar(objDate) {

   var i, leap=0, temp=0;
   var offset   = (Date.UTC(objDate.getFullYear(),objDate.getMonth(),objDate.getDate()) - Date.UTC(1900,0,31))/86400000;

   for(i=1900; i<2100 && offset>0; i++) { temp=lYearDays(i); offset-=temp; }

   if(offset<0) { offset+=temp; i--; }

   this.year = i;

   leap = leapMonth(i); //���ĸ���
   this.isLeap = false;

   for(i=1; i<13 && offset>0; i++) {
      //����
      if(leap>0 && i==(leap+1) && this.isLeap==false)
         { --i; this.isLeap = true; temp = leapDays(this.year); }
      else
         { temp = monthDays(this.year, i); }

      //�������
      if(this.isLeap==true && i==(leap+1)) this.isLeap = false;

      offset -= temp;
   }

   if(offset==0 && leap>0 && i==leap+1)
      if(this.isLeap)
         { this.isLeap = false; }
      else
         { this.isLeap = true; --i; }

   if(offset<0){ offset += temp; --i; }

   this.month = i;
   this.day = offset + 1;
}

//==============================���ع��� y��ĳm+1�µ�����
function solarDays(y,m) {
   if(m==1)
      return(((y%4 == 0) && (y%100 != 0) || (y%400 == 0))? 29: 28);
   else
      return(solarMonth[m]);
}
//============================== ���� offset ���ظ�֧, 0=����
function cyclical(num) {
   return(Gan[num%10]+Zhi[num%12]);
}

//============================== ��������
function calElement(sYear,sMonth,sDay,week,lYear,lMonth,lDay,isLeap,cYear,cMonth,cDay) {

      this.isToday    = false;
      //���
      this.sYear      = sYear;   //��Ԫ��4λ����
      this.sMonth     = sMonth;  //��Ԫ������
      this.sDay       = sDay;    //��Ԫ������
      this.week       = week;    //����, 1������
      //ũ��
      this.lYear      = lYear;   //��Ԫ��4λ����
      this.lMonth     = lMonth;  //ũ��������
      this.lDay       = lDay;    //ũ��������
      this.isLeap     = isLeap;  //�Ƿ�Ϊũ������?
      //����
      this.cYear      = cYear;   //����, 2������
      this.cMonth     = cMonth;  //����, 2������
      this.cDay       = cDay;    //����, 2������

      this.color      = '';

      this.lunarFestival = ''; //ũ������
      this.solarFestival = ''; //��������
      this.solarTerms    = ''; //����
}

//===== ĳ��ĵ�n������Ϊ����(��0С������)
function sTerm(y,n) {
   var offDate = new Date( ( 31556925974.7*(y-1900) + sTermInfo[n]*60000  ) + Date.UTC(1900,0,6,2,5) );
   return(offDate.getUTCDate());
}




//============================== ���������ؼ� (y��,m+1��)
/*
����˵��: ���������µ��������Ͽؼ�

ʹ�÷�ʽ: OBJ = new calendar(��,��������);

  OBJ.length      ���ص��������
  OBJ.firstWeek   ���ص���һ������

  �� OBJ[����].�������� ����ȡ�ø���ֵ

  OBJ[����].isToday  �����Ƿ�Ϊ���� true �� false

  ���� OBJ[����] ���Բμ� calElement() �е�ע��
*/
function calendar(y,m) {

   var sDObj, lDObj, lY, lM, lD=1, lL, lX=0, tmp1, tmp2, tmp3;
   var cY, cM, cD; //����,����,����
   var lDPOS = new Array(3);
   var n = 0;
   var firstLM = 0;

   sDObj = new Date(y,m,1,0,0,0,0);    //����һ������

   this.length    = solarDays(y,m);    //������������
   this.firstWeek = sDObj.getDay();    //��������1�����ڼ�

   ////////���� 1900��������Ϊ������(60����36)
   if(m<2) cY=cyclical(y-1900+36-1);
   else cY=cyclical(y-1900+36);
   var term2=sTerm(y,2); //��������

   ////////���� 1900��1��С����ǰΪ ������(60����12)
   var firstNode = sTerm(y,m*2) //���ص��¡��ڡ�Ϊ���տ�ʼ
   cM = cyclical((y-1900)*12+m+12);

   //����һ���� 1900/1/1 �������
   //1900/1/1�� 1970/1/1 ���25567��, 1900/1/1 ����Ϊ������(60����10)
   var dayCyclical = Date.UTC(y,m,1,0,0,0,0)/86400000+25567+10;

   for(var i=0;i<this.length;i++) {

      if(lD>lX) {
         sDObj = new Date(y,m,i+1);    //����һ������
         lDObj = new Lunar(sDObj);     //ũ��
         lY    = lDObj.year;           //ũ����
         lM    = lDObj.month;          //ũ����
         lD    = lDObj.day;            //ũ����
         lL    = lDObj.isLeap;         //ũ���Ƿ�����
         lX    = lL? leapDays(lY): monthDays(lY,lM); //ũ���������һ��

         if(n==0) firstLM = lM;
         lDPOS[n++] = i-lD+1;
      }

      //�������������·ֵ�����, ������Ϊ��
      if(m==1 && (i+1)==term2) cY=cyclical(y-1900+36);
      //����������, �ԡ��ڡ�Ϊ��
      if((i+1)==firstNode) cM = cyclical((y-1900)*12+m+13);
      //����
      cD = cyclical(dayCyclical+i);

      //sYear,sMonth,sDay,week,
      //lYear,lMonth,lDay,isLeap,
      //cYear,cMonth,cDay
      this[i] = new calElement(y, m+1, i+1, nStr1[(i+this.firstWeek)%7],
                               lY, lM, lD++, lL,
                               cY ,cM, cD );
   }

   //����
   tmp1=sTerm(y,m*2  )-1;
   tmp2=sTerm(y,m*2+1)-1;
   this[tmp1].solarTerms = solarTerm[m*2];
   this[tmp2].solarTerms = solarTerm[m*2+1];
   if(m==3) this[tmp1].color = 'red'; //������ɫ

   //��������
   for(i in sFtv)
      if(sFtv[i].match(/^(\d{2})(\d{2})([\s\*])(.+)$/))
         if(Number(RegExp.$1)==(m+1)) {
            this[Number(RegExp.$2)-1].solarFestival += RegExp.$4 + ' ';
            if(RegExp.$3=='*') this[Number(RegExp.$2)-1].color = 'red';
         }

   //���ܽ���
   for(i in wFtv)
      if(wFtv[i].match(/^(\d{2})(\d)(\d)([\s\*])(.+)$/))
         if(Number(RegExp.$1)==(m+1)) {
            tmp1=Number(RegExp.$2);
            tmp2=Number(RegExp.$3);
            if(tmp1<5)
               this[((this.firstWeek>tmp2)?7:0) + 7*(tmp1-1) + tmp2 - this.firstWeek].solarFestival += RegExp.$5 + ' ';
            else {
               tmp1 -= 5;
               tmp3 = (this.firstWeek+this.length-1)%7; //�������һ������?
               this[this.length - tmp3 - 7*tmp1 + tmp2 - (tmp2>tmp3?7:0) - 1 ].solarFestival += RegExp.$5 + ' ';
            }
         }

   //ũ������
   for(i in lFtv)
      if(lFtv[i].match(/^(\d{2})(.{2})([\s\*])(.+)$/)) {
         tmp1=Number(RegExp.$1)-firstLM;
         if(tmp1==-11) tmp1=1;
         if(tmp1 >=0 && tmp1<n) {
            tmp2 = lDPOS[tmp1] + Number(RegExp.$2) -1;
            if( tmp2 >= 0 && tmp2<this.length && this[tmp2].isLeap!=true) {
               this[tmp2].lunarFestival += RegExp.$4 + ' ';
               if(RegExp.$3=='*') this[tmp2].color = 'red';
            }
         }
      }


   //�����ֻ������3��4��
   if(m==2 || m==3) {
      var estDay = new easter(y);
      if(m == estDay.m)
         this[estDay.d-1].solarFestival = this[estDay.d-1].solarFestival+' ����� Easter Sunday';
   }


   if(m==2) this[20].solarFestival = this[20].solarFestival+unescape('%20%u6D35%u8CE2%u751F%u65E5');

   //��ɫ������
   if((this.firstWeek+12)%7==5)
      this[12].solarFestival += '��ɫ������';

   if(m==8) this[13].solarFestival = this[13].solarFestival+unescape('%u795D%u8D3A%u6885%u7AF9%u677E%u751F%u65E5%u5FEB%u4E50%u003A%u0029');

   //����
   if(y==tY && m==tM) this[tD-1].isToday = true;
}

//======================================= ���ظ���ĸ����(���ֺ��һ�������ܺ�ĵ�һ����)
function easter(y) {

   var term2=sTerm(y,5); //ȡ�ô�������
   var dayTerm2 = new Date(Date.UTC(y,2,term2,0,0,0,0)); //ȡ�ô��ֵĹ������ڿؼ�(����һ��������3��)
   var lDayTerm2 = new Lunar(dayTerm2); //ȡ��ȡ�ô���ũ��

   if(lDayTerm2.day<15) //ȡ���¸���Բ���������
      var lMlen= 15-lDayTerm2.day;
   else
      var lMlen= (lDayTerm2.isLeap? leapDays(y): monthDays(y,lDayTerm2.month)) - lDayTerm2.day + 15;

   //һ����� 1000*60*60*24 = 86400000 ����
   var l15 = new Date(dayTerm2.getTime() + 86400000*lMlen ); //�����һ����ԲΪ��������
   var dayEaster = new Date(l15.getTime() + 86400000*( 7-l15.getUTCDay() ) ); //����¸�����

   this.m = dayEaster.getUTCMonth();
   this.d = dayEaster.getUTCDate();

}

//====================== ��������
function cDay(d){
   var s;

   switch (d) {
      case 10:
         s = '��ʮ'; break;
      case 20:
         s = '��ʮ'; break;
         break;
      case 30:
         s = '��ʮ'; break;
         break;
      default :
         s = nStr2[Math.floor(d/10)];
         s += nStr1[d%10];
   }
   return(s);
}

///////////////////////////////////////////////////////////////////////////////

var cld;

function drawCld(SY,SM) {
   var i,sD,s,size;
   cld = new calendar(SY,SM);

   if(SY>1874 && SY<1909) yDisplay = '����' + (((SY-1874)==1)?'Ԫ':SY-1874);
   if(SY>1908 && SY<1912) yDisplay = '��ͳ' + (((SY-1908)==1)?'Ԫ':SY-1908);
   if(SY>1911 && SY<1950) yDisplay = '���' + (((SY-1911)==1)?'Ԫ':SY-1911);
   if(SY>1948) yDisplay = '����' + (((SY-1949)==1)?'Ԫ':SY-1949);

   GZ.innerHTML = yDisplay +'�� ũ�� ' + cyclical(SY-1900+36) + '�� ��'+Animals[(SY-4)%12]+'�꡿';

   YMBG.innerHTML = "&nbsp;" + SY + "<BR>&nbsp;" + monthName[SM];

   for(i=0;i<42;i++) {

      sObj=eval('SD'+ i);
      lObj=eval('LD'+ i);

      sObj.className = '';

      sD = i - cld.firstWeek;

      if(sD>-1 && sD<cld.length) { //������
         sObj.innerHTML = sD+1;

         if(cld[sD].isToday) sObj.className = 'todyaColor'; //������ɫ

         sObj.style.color = cld[sD].color; //����������ɫ

         if(cld[sD].lDay==1) //��ʾũ����
            lObj.innerHTML = '<b>'+(cld[sD].isLeap?'��':'') + cld[sD].lMonth + '��' + (monthDays(cld[sD].lYear,cld[sD].lMonth)==29?'С':'��')+'</b>';
         else //��ʾũ����
            lObj.innerHTML = cDay(cld[sD].lDay);

         s=cld[sD].lunarFestival;
         if(s.length>0) { //ũ������
            if(s.length>6) s = s.substr(0, 4)+'...';
            s = s.fontcolor('red');
         }
         else { //��������
            s=cld[sD].solarFestival;
            if(s.length>0) {
               size = (s.charCodeAt(0)>0 && s.charCodeAt(0)<128)?8:4;
               if(s.length>size+2) s = s.substr(0, size)+'...';
               s=(s=='��ɫ������')?s.fontcolor('black'):s.fontcolor('blue');
            }
            else { //إ�Ľ���
               s=cld[sD].solarTerms;
               if(s.length>0) s = s.fontcolor('limegreen');
            }
         }

         if(cld[sD].solarTerms=='����') s = '������'.fontcolor('red');
         if(cld[sD].solarTerms=='â��') s = 'â��'.fontcolor('red');
         if(cld[sD].solarTerms=='����') s = '����'.fontcolor('red');
         if(cld[sD].solarTerms=='����') s = '����'.fontcolor('red');



         if(s.length>0) lObj.innerHTML = s;

      }
      else { //������
         sObj.innerHTML = '';
         lObj.innerHTML = '';
      }
   }
}


function changeCld() {
   var y,m;
   y=document.all["SY"].selectedIndex+1900;
   m=document.all["SM"].selectedIndex;
   drawCld(y,m);
}

function pushBtm(K) {
 switch (K){
    case 'YU' :
       if(document.all["SY"].selectedIndex>0) document.all["SY"].selectedIndex--;
       break;
    case 'YD' :
       if(document.all["SY"].selectedIndex<200) document.all["SY"].selectedIndex++;
       break;
    case 'MU' :
       if(document.all["SM"].selectedIndex>0) {
          document.all["SM"].selectedIndex--;
       }
       else {
          document.all["SM"].selectedIndex=11;
          if(document.all["SY"].selectedIndex>0) document.all["SY"].selectedIndex--;
       }
       break;
    case 'MD' :
       if(document.all["SM"].selectedIndex<11) {
          document.all["SM"].selectedIndex++;
       }
       else {
          document.all["SM"].selectedIndex=0;
          if(document.all["SY"].selectedIndex<200) document.all["SY"].selectedIndex++;
       }
       break;
    default :
       document.all["SY"].selectedIndex=tY-1900;
       document.all["SM"].selectedIndex=tM;
 }
 changeCld();
}

var Today = new Date();
var tY = Today.getFullYear();
var tM = Today.getMonth();
var tD = Today.getDate();
//////////////////////////////////////////////////////////////////////////////

var width = "130";
var offsetx = 2;
var offsety = 8;

var x = 0;
var y = 0;
var snow = 0;
var sw = 0;
var cnt = 0;

var dStyle;
document.onmousemove = mEvn;

//��ʾ��ϸ��������
function mOvr(v) {
   var s,festival;
   var sObj=eval('SD'+ v);
   var d=sObj.innerHTML-1;

      //sYear,sMonth,sDay,week,
      //lYear,lMonth,lDay,isLeap,
      //cYear,cMonth,cDay

   if(sObj.innerHTML!='') {

      sObj.style.cursor = 's-resize';

      if(cld[d].solarTerms == '' && cld[d].solarFestival == '' && cld[d].lunarFestival == '')
         festival = '';
      else
         festival = '<TABLE WIDTH=100% BORDER=0 CELLPADDING=2 CELLSPACING=0 BGCOLOR="#CCFFCC"><TR><TD>'+
         '<FONT COLOR="#000000" STYLE="font-size:9pt;">'+cld[d].solarTerms + ' ' + cld[d].solarFestival + ' ' + cld[d].lunarFestival+'</FONT></TD>'+
         '</TR></TABLE>';

      s= '<TABLE WIDTH="130" BORDER=0 CELLPADDING="2" CELLSPACING=0 BGCOLOR="<%=rptTable_cgColor%>" style="filter:Alpha(opacity=80)"><TR><TD>' +
         '<TABLE WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD ALIGN="right"><FONT COLOR="#ffffff" STYLE="font-size:9pt;">'+
         cld[d].sYear+' �� '+cld[d].sMonth+' �� '+cld[d].sDay+' ��<br>����'+cld[d].week+'<br>'+
         '<font color="violet">ũ��'+(cld[d].isLeap?'�� ':' ')+cld[d].lMonth+' �� '+cld[d].lDay+' ��</font><br>'+
         '<font color="yellow">'+cld[d].cYear+'�� '+cld[d].cMonth+'�� '+cld[d].cDay + '��</font>'+
         '</FONT></TD></TR></TABLE>'+ festival +'</TD></TR></TABLE>';

      document.all["detail"].innerHTML = s;

      if (snow == 0) {
         dStyle.left = x+offsetx-(width/2);
         dStyle.top = y+offsety;
         dStyle.visibility = "visible";
         snow = 1;
      }
   }
}

//�����ϸ��������
function mOut() {
   if ( cnt >= 1 ) { sw = 0; }
   if ( sw == 0 ) { snow = 0; dStyle.visibility = "hidden";}
   else cnt++;
}

//ȡ��λ��
function mEvn() {
   x=event.x;
   y=event.y;
   if (document.body.scrollLeft)
      {x=event.x+document.body.scrollLeft; y=event.y+document.body.scrollTop;}
   if (snow){
      dStyle.left = x+offsetx-(width/2);
      dStyle.top = y+offsety;
   }
}

function initialize() {
   //����
   dStyle = detail.style;
   document.all["SY"].selectedIndex=tY-1900;
   document.all["SM"].selectedIndex=tM;
   drawCld(tY,tM);

}