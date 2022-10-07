using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blake;

public class BloodHoundJSONMetaData 
{
    public int methods { get; set; }
    public string type { get; set; }
    public int count { get; set; }
    public int version { get; set; }
}

public class BloodHoundJSONWrapper<T>
{
    public List<T> data { get; set; }
    public BloodHoundJSONMetaData meta { get; set; }

    public BloodHoundJSONWrapper(object deserializedJson) 
    { 
        //List
    }
}


public class BloodHoundData
{
    public List<Computer> computers { get; set; }
    public List<Container> containers { get; set; }
    public List<Domain> domains { get; set; }
    public List<GroupPolicy> groupPolicies { get; set; }
    public List<Group> groups { get; set; }
    public List<OrganizationalUnit> organizationalUnits { get; set; }
    public List<User> users { get; set; }

    public BloodHoundData(List<Computer> computers, List<Container> containers, List<Domain> domains, List<GroupPolicy> groupPolicies, List<Group> groups, List<OrganizationalUnit> organizationalUnits, List<User> users)
    {
        computers = computers;
        containers = containers;
        domains = domains;
        groupPolicies = groupPolicies;
        groups = groups;
        users = users;
    }

    public BloodHoundData() { }
}
