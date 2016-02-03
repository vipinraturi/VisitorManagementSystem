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

        public IQueryable<BuildingBO> GetAllBuildings()
        {
            return m_unitOfWork.GetRepository<BuildingBO>().GetAll();
        }

        public IQueryable<BuildingBO> GetManyBuidings()
        {
            // TO DO:
            //return m_unitOfWork.GetRepository<Building>().SearchFor(x=>x.);
            throw new NotImplementedException();
        }

        public BuildingBO GetBuildingInfo(int buildingId)
        {
            return m_unitOfWork.GetRepository<BuildingBO>().GetById(buildingId);
        }

        public bool DeleteBuilding(int buildingId)
        {
            m_unitOfWork.GetRepository<BuildingBO>().DeleteById(buildingId);
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

        public Company Insert(Company company)
        {
            var insertedRecord = m_unitOfWork.GetRepository<Company>().Insert(company);
            m_unitOfWork.Commit();
            return insertedRecord;
        }

        public void Update(Company company)
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
    }
}
