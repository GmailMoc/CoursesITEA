using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public interface ILoadFile
    {
        public byte[] GetImage(string imageName);
        public void CacheSet(byte[] image, string imageName);
    }
}
