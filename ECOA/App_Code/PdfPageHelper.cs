using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// PdfPageHelper 的摘要说明
/// </summary>
public class PdfPageHelper: PdfPageEventHelper
{
    PdfContentByte cb; 
    PdfTemplate template;
   iTextSharp.text.pdf.BaseFont bfChinese = iTextSharp.text.pdf.BaseFont.CreateFont("C://WINDOWS//Fonts//simsun.ttc,1", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
    public override void OnOpenDocument(PdfWriter writer, Document document)
    {
        cb = writer.DirectContent;
        template = cb.CreateTemplate(50, 50);
    }
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        base.OnEndPage(writer, document);
        int pageN = writer.PageNumber;
        String text = "Page " + pageN.ToString() + " of ";
        float len = this.bfChinese.GetWidthPoint(text,  12);
        iTextSharp.text.Rectangle pageSize = document.PageSize;
        cb.SetRGBColorFill(100, 100, 100);
        cb.BeginText();
        cb.SetFontAndSize(bfChinese, 12);
        cb.SetTextMatrix((document.PageSize.Width - len) / 2f, pageSize.GetBottom(document.BottomMargin));
     //   cb.SetTextMatrix(1, 1);//定位“第x页,共” 在具体的页面调试时候需要更改这xy的坐标  
        cb.ShowText(text);
        cb.EndText();
        cb.AddTemplate(template, (document.PageSize.Width + len) / 2f, pageSize.GetBottom(document.BottomMargin));
        
    }
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        base.OnCloseDocument(writer, document); 
        template.BeginText();
        template.SetFontAndSize(bfChinese, 12);
        template.SetTextMatrix(0, 0);
        template.ShowText("" + (writer.PageNumber - 1));
        template.EndText();
    }
}