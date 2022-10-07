using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blake;

public class Ace
{
    public string PrincipalSID { get; set; }
    public string PrincipalType { get; set; }
    public string RightName { get; set; }
    public bool IsInherited { get; set; }
}

public class Properties
{
    public string domain { get; set; }
    public string name { get; set; }
    public string distinguishedname { get; set; }
    public string domainsid { get; set; }
    public bool highvalue { get; set; }
}

public class Container
{
    public Properties Properties { get; set; }
    public List<object> ChildObjects { get; set; }
    public List<Ace> Aces { get; set; }
    public string ObjectIdentifier { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsACLProtected { get; set; }
}
