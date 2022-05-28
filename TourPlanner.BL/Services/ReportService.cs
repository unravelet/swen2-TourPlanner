﻿using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.BL.Services {
    public class ReportService {

        public ReportService() {

            
        }
        private static Cell getHeaderCell(String s) {
            return new Cell().Add(new Paragraph(s)).SetBold().SetBackgroundColor(ColorConstants.GRAY);
        }


        public void GenerateReport(string name, Tour tour, ObservableCollection<TourLog> tourlogs) { 
            const string LOREM_IPSUM_TEXT = "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            const string GOOGLE_MAPS_PNG = "./google_maps.png";
            const string TARGET_PDF = "target.pdf";

            PdfWriter writer = new PdfWriter(TARGET_PDF);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph loremIpsumHeader = new Paragraph("Lorem Ipsum header...")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                    .SetFontSize(14)
                    .SetBold()
                    .SetFontColor(ColorConstants.RED);
            document.Add(loremIpsumHeader);
            document.Add(new Paragraph(LOREM_IPSUM_TEXT));

            Paragraph listHeader = new Paragraph("Lorem Ipsum ...")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
                    .SetFontSize(14)
                    .SetBold()
                    .SetFontColor(ColorConstants.BLUE);
            List list = new List()
                    .SetSymbolIndent(12)
                    .SetListSymbol("\u2022")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD));
            list.Add(new ListItem("lorem ipsum 1"))
                        .Add(new ListItem("lorem ipsum 2"))
                        .Add(new ListItem("lorem ipsum 3"))
                        .Add(new ListItem("lorem ipsum 4"))
                        .Add(new ListItem("lorem ipsum 5"))
                        .Add(new ListItem("lorem ipsum 6"));
            document.Add(listHeader);
            document.Add(list);

            Paragraph tableHeader = new Paragraph("Lorem Ipsum Table ...")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
                    .SetFontSize(18)
                    .SetBold()
                    .SetFontColor(ColorConstants.GREEN);
            document.Add(tableHeader);
            Table table = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
            table.AddHeaderCell(getHeaderCell("Ipsum 1"));
            table.AddHeaderCell(getHeaderCell("Ipsum 2"));
            table.AddHeaderCell(getHeaderCell("Ipsum 3"));
            table.AddHeaderCell(getHeaderCell("Ipsum 4"));
            table.SetFontSize(14).SetBackgroundColor(ColorConstants.WHITE);
            table.AddCell("lorem 1");
            table.AddCell("lorem 2");
            table.AddCell("lorem 3");
            table.AddCell("lorem 4");
            document.Add(table);

            document.Add(new AreaBreak());

            Paragraph imageHeader = new Paragraph("Lorem Ipsum Image ...")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
                    .SetFontSize(18)
                    .SetBold()
                    .SetFontColor(ColorConstants.GREEN);
            document.Add(imageHeader);
            ImageData imageData = ImageDataFactory.Create(GOOGLE_MAPS_PNG);
            document.Add(new Image(imageData));

            document.Close();
        }

    }
    

}
