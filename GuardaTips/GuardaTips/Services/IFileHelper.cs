using System;
using System.Collections.Generic;
using System.Text;

namespace GuardaTips.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
