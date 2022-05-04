using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
        public interface IPdf
        {
            string headerContent { get; set; }
            IBodyPdf BodyContent { get; set; }
            string xRefContent { get; set; }
            string TrailerContent { get; set; }

            bool SaveFile(string filePath, string fileName);

        }

}
