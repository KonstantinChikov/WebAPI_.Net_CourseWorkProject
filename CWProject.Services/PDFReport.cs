using CWProject.Services.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Services
{
    public class PDFReport : IPDFReport
    {
        private readonly IConverter _converter;
        private readonly IVillasService _villasService;
        private readonly IVillaAmenitiesService _villaAmenitiesService;
        private readonly IAmenitiesService _amenitiesService;
        private readonly ILocationTypeService _locationTypeService;

        public PDFReport(
                        IVillasService villasService,
                        IVillaAmenitiesService villaAmenitiesService,
                        IAmenitiesService amenitiesService,
                        ILocationTypeService locationTypeService,
                        IConverter converter)
        {
            _converter = converter;
            _villasService = villasService;
            _villaAmenitiesService = villaAmenitiesService;
            _amenitiesService = amenitiesService;
            _locationTypeService = locationTypeService;


        }

        public void ExportPDF()
        {
            GlobalSettings globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = "PdfReport.pdf"
            };

            ObjectSettings objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetPdfContent(),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial" },
                FooterSettings = { FontName = "Arial" }
            };

            HtmlToPdfDocument pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);
        }

        private string GetPdfContent()
        {
            return

$@"<html>
    <head>
        <style>
            .header {{
                text-align: center;
                color: green;
                padding-bottom: 35px;
            }}

            table {{
                width: 80%;
                border-collapse: collapse;
                margin: 0 auto;
            }}

            td, th {{
                border: 1px solid gray;
                padding: 15px;
                font-size: 22px;
                text-align: center;
            }}

            table th {{
                background-color: green;
                color: white;
            }}
        </style>
    </head>
    <body>
        <div class='header'>
            <h1>PDF Report</h1>
        </div>
        <table>
            <thead>
                <th>Entity Name</th>
                <th>Count</th>
            </thead>
            <tr>
                <td>Villas</td>
                <td>{_villasService.GetCount()}</td>
            </tr>
            <tr>
                <td>VillaAmenities</td>
                <td>{_villaAmenitiesService.GetCount()}</td>
            </tr>
            <tr>
                <td>Amenities</td>
                <td>{_amenitiesService.GetCount()}</td>
            </tr>
            <tr>
                <td>LocationTypes</td>
                <td>{_locationTypeService.GetCount()}</td>
            </tr>
        </table>
    </body>
</html>";
        }
    }
}
