using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
namespace TM.Core {
    //HttpContext
    public class PDF {
        // private PdfDocument doc = new PdfDocument();
        private string _fileName = "";
        public PDF() {

        }
        public PDF(string fileName) {
            // create a new pdf document
            this._fileName = fileName;
            // doc = new PdfDocument(this._fileName);
        }
        public void CompressPDF() {
            // set compression level
            // doc.CompressionLevel = PdfCompressionLevel.Best;

            // save pdf document
            // doc.Save(this._fileName);

            // close pdf document
            // doc.Close();
        }
    }
}