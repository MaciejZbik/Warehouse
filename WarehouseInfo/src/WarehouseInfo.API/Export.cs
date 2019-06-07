using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
namespace WarehouseInfo.API
{
    public class Export
    {
        int i = 0;
        string sWebRootFolder = _hostingEnvironment.WebRootPath;
        string sFileName = @"demo.xlsx";
        string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
        FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        var memory = new MemoryStream();
    using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
    {
        IWorkbook workbook;
    workbook = new XSSFWorkbook();
    ISheet excelSheet = workbook.CreateSheet("Demo");
    IRow row = excelSheet.CreateRow(0);

    row.CreateCell(0).SetCellValue("ID");
    row.CreateCell(1).SetCellValue("Name");
    row.CreateCell(2).SetCellValue("Item");
        
        do
        row = excelSheet.CreateRow(1);
        row.CreateCell(0).SetCellValue(PointsOfInterest.Id(i));
        row.CreateCell(1).SetCellValue(PointsOfInterest(i).Description(i));
        row.CreateCell(2).SetCellValue(PointsOfInterest(i).Item(i));
        row.CreateCell(3).SetCellValue(PointsOfInterest(i).Item(i+1));
        i++;
        while(i != PointsOfInterest.Count)
    workbook.Write(fs);
    }
    using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
    {
        await stream.CopyToAsync(memory);
    }
    memory.Position = 0;
    return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
}
    }
}
