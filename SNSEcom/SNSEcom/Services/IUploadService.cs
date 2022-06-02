using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Services
{
    public interface IUploadService
    {
        bool Upload(SingleFileModel model);
       
    }
}
