using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Business
{
    public class BuildingBO : IBuildingBO
    {
        private readonly IUnitOfWork m_unitOfWork;

        public BuildingBO(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }
        public BuildingBO() //IUnitOfWork unitOfWork)
        {
            m_unitOfWork = new UnitOfWork();
        }

        public Company GetCompanyInformation()
        {
            return m_unitOfWork.GetRepository<Company>().GetAll().FirstOrDefault();
        }

        public IQueryable<Building> GetAllBuildings()
        {
            return m_unitOfWork.GetRepository<Building>().GetAll();
        }

        public IQueryable<Building> GetManyBuidings()
        {
            // TO DO:
            //return m_unitOfWork.GetRepository<Building>().SearchFor(x=>x.);
            throw new NotImplementedException();
        }

        public Building GetBuildingInfo(int buildingId)
        {
            return m_unitOfWork.GetRepository<Building>().GetById(buildingId);
        }

        public bool DeleteBuilding(int buildingId)
        {
            m_unitOfWork.GetRepository<Building>().DeleteById(buildingId);
            m_unitOfWork.Commit();
            return true;
        }

        public IQueryable<BuildingGate> GetAllBuildingGates()
        {
            return m_unitOfWork.GetRepository<BuildingGate>().GetAll();
        }

        public IQueryable<BuildingGate> GetManyBuidingGates()
        {
            throw new NotImplementedException();
        }

        public BuildingGate GetBuildingGateInfo(int buildingGateId)
        {
            return m_unitOfWork.GetRepository<BuildingGate>().GetById(buildingGateId);
        }

        public bool DeleteBuildingGate(int buildingGateId)
        {
            m_unitOfWork.GetRepository<BuildingGate>().DeleteById(buildingGateId);
            m_unitOfWork.Commit();
            return true;
        }

        public Company InsertCompany(Company company)
        {
            var insertedRecord = m_unitOfWork.GetRepository<Company>().Insert(company);
            m_unitOfWork.Commit();
            return insertedRecord;
        }

        public void UpdateCompany(Company company)
        {
            var existingRecord = m_unitOfWork.GetRepository<Company>().GetById(company.Id);
            existingRecord.CompanyName = company.CompanyName;
            existingRecord.Description = company.Description;
            existingRecord.Email = company.Email;
            existingRecord.Address = company.Address;
            existingRecord.Fax = company.Fax;
            existingRecord.MobileNumber = company.MobileNumber;
            existingRecord.PhoneNumber = company.PhoneNumber;
            existingRecord.WebSite = company.WebSite;
            existingRecord.ZipCode = company.ZipCode;
            m_unitOfWork.GetRepository<Company>().Update(existingRecord);
            m_unitOfWork.Commit();
        }

        public Building InsertBuilding(Building building)
        {
            var insertedBuilding = m_unitOfWork.GetRepository<Building>().Insert(building);
            m_unitOfWork.Commit();
            return insertedBuilding;
        }

        public bool UpdateBuilding(Building building)
        {
            var existingRecord = m_unitOfWork.GetRepository<Building>().GetById(building.Id);
            existingRecord.Address = building.Address;
            existingRecord.Name = building.Name;
            existingRecord.Description = building.Description;
            existingRecord.Email = building.Email;
            existingRecord.PhoneNumber = building.PhoneNumber;
            existingRecord.ZipCode = building.ZipCode;
            existingRecord.Region = building.Region;
            existingRecord.Country = building.Country;
            existingRecord.State = building.State;
            existingRecord.City = building.City;
            m_unitOfWork.GetRepository<Building>().Update(existingRecord);
            m_unitOfWork.Commit();
            return true;
        }

        public BuildingGate InsertBuildingGate(BuildingGate buildingGate)
        {
            var insertedBuildingGate = m_unitOfWork.GetRepository<BuildingGate>().Insert(buildingGate);
            m_unitOfWork.Commit();
            return insertedBuildingGate;
        }

        public bool UpdateBuildingGate(BuildingGate buildingGate)
        {
            var existingRecord = m_unitOfWork.GetRepository<BuildingGate>().GetById(buildingGate.Id);
            existingRecord.GateNumber = buildingGate.GateNumber;
            existingRecord.Description = buildingGate.Description;
            existingRecord.PhoneNumber = buildingGate.PhoneNumber;
            existingRecord.BuildingId = buildingGate.BuildingId;
            m_unitOfWork.GetRepository<BuildingGate>().Update(existingRecord);
            m_unitOfWork.Commit();
            return true;
        }

        public IQueryable<BuildingLocation> GetAllBuildingLocations()
        {
            return m_unitOfWork.GetRepository<BuildingLocation>().GetAll();
        }
    }
}
