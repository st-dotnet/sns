using SNSEcom.Data;
using SNSEcom.Domain;
using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Services
{
    public class UploadService : IUploadService
    {
        public SNSContext _context { get; }
        public UploadService(SNSContext context)
        {
            _context = context;
        }
        public bool Upload(SingleFileModel model)
        {
            try
            {
                model.IsResponse = true;
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                FileInfo fileInfo = new FileInfo(model.File.FileName);
                string fileName = model.FileName + fileInfo.Extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.File.CopyToAsync(stream);
                }

                var csvFile = File.ReadAllLines(path);
                var productRec = from csvline in csvFile
                            let data = csvline.Split(',')
                            select new
                            {
                                Description = data[0],
                                SKU = data[1],
                                Quantity = data[2],
                                Price = data[3]
                            };
                                var columnCount = productRec.Skip(1).ToList();
                                try
                                {
                                            for (int column = 0; column < columnCount.Count; column++)
                                            {
                                                Products stockdata = new()
                                                {
                                                    Description = columnCount[column].Description,
                                                    Price = columnCount[column].Price,
                                                    SKU = columnCount[column].SKU,
                                                    Quantity = columnCount[column].Quantity,
                                                };
                                                _context.product.Add(stockdata);
                                            }
                                        _context.SaveChanges();
                                        model.IsResponse = true;
                                        model.Message = "Files upload successfully";
                                        File.Delete(path);
                                        return true;
                                
                                }
                                catch (Exception)
                                {
                                    model.IsResponse = false;
                                    model.Message = "Please select files";
                                    return false;
                                    throw;
                                }
            }
            catch (Exception)
            {
                model.IsResponse = false;
                model.Message = "Please select files";
                return false;
                throw;
            }
        }

    }
}
