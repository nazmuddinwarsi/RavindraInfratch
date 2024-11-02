using System;
using System.Collections.Generic;

namespace RavindraInfratch.DBData;

public partial class LogTblUserRight
{
    public byte? ModuleId { get; set; }

    public byte? UserId { get; set; }

    public bool? FldAdd { get; set; }

    public bool? FldEdit { get; set; }

    public bool? FldDelete { get; set; }

    public bool? FldView { get; set; }
}
