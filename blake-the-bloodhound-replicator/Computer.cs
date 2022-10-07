using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blake;

public class Computer 
{ 


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Ace
{
    public string PrincipalSID { get; set; }
    public string PrincipalType { get; set; }
    public string RightName { get; set; }
    public bool IsInherited { get; set; }
}

public class DcomUsers
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}

public class LocalAdmins
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}

public class PrivilegedSessions
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}

public class Properties
{
    public string domain { get; set; }
    public string name { get; set; }
    public string distinguishedname { get; set; }
    public string domainsid { get; set; }
    public bool highvalue { get; set; }
    public string samaccountname { get; set; }
    public bool haslaps { get; set; }
    public string description { get; set; }
    public int whencreated { get; set; }
    public bool enabled { get; set; }
    public bool unconstraineddelegation { get; set; }
    public bool trustedtoauth { get; set; }
    public int lastlogon { get; set; }
    public int lastlogontimestamp { get; set; }
    public int pwdlastset { get; set; }
    public List<object> serviceprincipalnames { get; set; }
    public object operatingsystem { get; set; }
    public List<object> sidhistory { get; set; }
}

public class PSRemoteUsers
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}

public class RegistrySessions
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}

public class RemoteDesktopUsers
{
    public List<object> Results { get; set; }
    public bool Collected { get; set; }
    public object FailureReason { get; set; }
}
    public class Sessions
    {
        public List<object> Results { get; set; }
        public bool Collected { get; set; }
        public object FailureReason { get; set; }
    }
}





