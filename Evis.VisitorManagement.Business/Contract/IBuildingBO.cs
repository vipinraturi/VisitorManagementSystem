using Evis.VisitorManagement.DataProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Business.Contract
{
    public interface IBuildingBO
    {
        Company GetCompanyInformation();

        Company Insert(Company company);

        void Update(Company company);

        IQueryable<BuildingBO> GetAllBuildings();

        IQueryable<BuildingBO> GetManyBuidings();

        BuildingBO GetBuildingInfo(int buildingId);

        bool DeleteBuilding(int buildingId);

        IQueryable<BuildingGate> GetAllBuildingGates();

        IQueryable<BuildingGate> GetManyBuidingGates();

        BuildingGate GetBuildingGateInfo(int buildingGateId);

        bool DeleteBuildingGate(int buildingGateId);

        
    }
}
