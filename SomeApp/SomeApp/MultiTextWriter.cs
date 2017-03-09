using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace SomeApp
{
    //from http://stackoverflow.com/questions/17063975/sending-console-output-to-multiple-writers with typo fixing
    public class MultiTextWriter : TextWriter
    {
        private List<TextWriter> _writers = new List<TextWriter>();

        public override Encoding Encoding
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddWriter(TextWriter writer)
        {
            _writers.Add(writer);
        }

        public override void Write(char ch)
        {
            foreach (var writer in _writers)
            {
                try
                {
                    writer.Write(ch);
                }
                catch (ObjectDisposedException)
                {
                    // handle exception here
                }
                catch (IOException)
                {
                    // handle exception here
                }
            }
        }
    }
}
