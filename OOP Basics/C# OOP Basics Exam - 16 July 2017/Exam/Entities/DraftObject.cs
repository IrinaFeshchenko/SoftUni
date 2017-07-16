using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class DraftObject
{
    private string id;

    protected DraftObject(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}
