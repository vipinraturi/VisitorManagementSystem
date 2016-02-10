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

        Company InsertCompany(Company company);

        void UpdateCompany(Company company);

        IQueryable<Building> GetAllBuildings();

        IQueryable<Building> GetManyBuidings();

        Building GetBuildingInfo(int buildingId);

        bool DeleteBuilding(int buildingId);

        Building InsertBuilding(Building building);

        bool UpdateBuilding(Building building);

        BuildingGate InsertBuildingGate(BuildingGate buildingGate);

        bool UpdateBuildingGate(BuildingGate buildingGate);

        IQueryable<BuildingGate> GetAllBuildingGates();

        IQueryable<BuildingGate> GetManyBuidingGates();

        BuildingGate GetBuildingGateInfo(int buildingGateId);

        bool DeleteBuildingGate(int buildingGateId);

        IQueryable<BuildingLocation> GetAllBuildingLocations();

        FileUpload InsertImage(FileUpload fileUpload);

        bool UpdateImage(FileUpload fileUpload);

        FileUpload GetImage(string userId);
    }
}
