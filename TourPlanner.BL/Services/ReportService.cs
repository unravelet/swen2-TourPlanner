using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.BL.Services {
    public class ReportService {
        private string _path; 
        public ReportService() {
            _path = Environment.CurrentDirectory + "/reports";
            Directory.CreateDirectory(_path);

        }
        public void GenerateSummary(ObservableCollection<Tour> tourCollection) {

            string TARGET_PDF = $"{_path}/Report_{GetTimeStamp()}.pdf";

            PdfWriter writer = new PdfWriter(TARGET_PDF);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            List<Tour> tours = new List<Tour>();

            foreach (Tour tour in tourCollection) {
                tours.Add(tour);
            }

            GenerateTourSummary(document, tours);


            document.Close();
        }

        public void GenerateSingleReport(Tour tour, ObservableCollection<TourLog> tourlogs) {
            string MAP_IMG = $"{Environment.CurrentDirectory}" + $"/img/{tour.Id}.jpg";

            string TARGET_PDF = $"{_path}/{tour.Name}_{GetTimeStamp()}.pdf";

            PdfWriter writer = new PdfWriter(TARGET_PDF);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            List<TourLog> tourLogList = new List<TourLog>();

            foreach (TourLog tourLog in tourlogs) {
                tourLogList.Add(tourLog);
            }

            GenerateReport(document, MAP_IMG, tour, tourLogList);

            document.Close();
        }

        public void GenerateReport(Document document, string MAP_IMG, Tour tour, List<TourLog> tourLogList) {


            AddTourInfo(document, tour);

            AddImage(document, MAP_IMG);

            AddLogTable(document, tourLogList);


        }

        public void GenerateTourSummary(Document document, List<Tour> tours) {

            string AVGRATING = $"Average rating of all tours: {CalAvgRating(tours)}";

            document.Add(new Paragraph(AVGRATING));

            foreach (Tour tour in tours) {

                string MAP_IMG = $"{Environment.CurrentDirectory}" + $"/img/{tour.Id}.jpg";
                AddTourInfo(document, tour);

                AddImage(document, MAP_IMG);
                document.Add(new AreaBreak());

            }

        }

        private double CalAvgRating(List<Tour> tours) {
            

            List<double> ratingList = new List<double>();
            foreach (var tour in tours) {

                ratingList.Add(tour.AvgRating);
            }
            return ratingList.Average();

        }

        public string GetTimeStamp() {

            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        void AddNewLine(Document document) {
            document.Add(new Paragraph(""));
        }

        static Cell getHeaderCell(String s) {
            return new Cell().Add(new Paragraph(s))
                .SetBold()
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetFontSize(11)
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
        }

        void AddTourInfo(Document document, Tour tour) {
            string FROM_ADDRESS = $"{tour.StartAddress} {tour.StartAddressNum}, {tour.StartZip} {tour.StartCity}, {tour.StartCountry}";
            string TO_ADDRESS = $"{tour.EndAddress} {tour.EndAddressNum}, {tour.EndZip} {tour.EndCity}, {tour.EndCountry}";
            string TRANSPORT = $"Transport: {tour.TransportType.ToString()}";
            string AVGRATING = $"Average rating: {tour.AvgRating}";
            if(tour.AvgRating < 1) {
                AVGRATING = "Average rating: No logs";
            }


            Paragraph TourName = new Paragraph(tour.Name)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                    .SetFontSize(14)
                    .SetBold()
                    .SetFontColor(ColorConstants.RED);
            document.Add(TourName);
            Paragraph Description = new Paragraph("Description").SetBold();
            document.Add(Description);
            document.Add(new Paragraph(tour.Description));

            AddNewLine(document);

            document.Add(new Paragraph(TRANSPORT));

            AddNewLine(document);

            document.Add(new Paragraph(AVGRATING));

            AddNewLine(document);

            document.Add(new Paragraph("From: " + FROM_ADDRESS));
            document.Add(new Paragraph("To: " + TO_ADDRESS));

            AddNewLine(document);
            AddNewLine(document);
        }

        void AddLogTable(Document document, List<TourLog> tourLogList) {
            Paragraph tableHeader = new Paragraph("Logs")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                    .SetFontSize(12)
                    .SetBold()
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE);
            document.Add(tableHeader);
            Table table = new Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();
            table.AddHeaderCell(getHeaderCell("Date"));
            table.AddHeaderCell(getHeaderCell("Duration"));
            table.AddHeaderCell(getHeaderCell("Distance"));
            table.AddHeaderCell(getHeaderCell("Rating"));
            table.AddHeaderCell(getHeaderCell("Difficulty"));
            table.AddHeaderCell(getHeaderCell("Comment"));
            table.SetFontSize(11).SetBackgroundColor(ColorConstants.WHITE);
            foreach (var item in tourLogList) {
                table.AddCell(item.Date);
                table.AddCell(item.Duration);
                table.AddCell(item.Distance);
                table.AddCell(item.Rating);
                table.AddCell(item.Difficulty);
                table.AddCell(item.Comment);
            }

            document.Add(table);

            AddNewLine(document);

        }

        void AddImage(Document document, string imgPath) {

            ImageData imageData = ImageDataFactory.Create(imgPath);
            Image image = new Image(imageData);
            image
                .ScaleAbsolute(350, 350)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);

            document.Add(image);

            AddNewLine(document);
            AddNewLine(document);
        }






    }


}
