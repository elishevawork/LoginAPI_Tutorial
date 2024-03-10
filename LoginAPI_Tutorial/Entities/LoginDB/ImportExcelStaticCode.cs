using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class ImportExcelStaticCode
{
    public int ExcelImportType { get; set; }

    public string Code { get; set; } = null!;
}
