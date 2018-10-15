using LC.ClassLibraries.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    /// <summary>
    /// Project
    /// </summary>
    public partial class Project
    {
        private readonly Dal.Project dal = new Dal.Project();
        public Project()
        { }
        #region  BasicMethod

        public List<Project> getcesshi(string userid) {
            try
            {
                StringBuilder str = new StringBuilder();
                return LCDBHelper.GetAllList<Project>("userid=@userid", new SqlParameter[] {new SqlParameter("@userid", userid) });
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Project model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Project model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetuserModel(int Id)
        {

            return dal.GetuserModel(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetModels()
        {

            return dal.GetModels();
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetModelss(string strwhere)
        {

            return dal.GetModelss(strwhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetModelsstow(int projectid)
        {

            return dal.GetModelsstow(projectid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Project> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Project> DataTableToList(DataTable dt)
        {
            List <Model.Project > modelList = new List<Model.Project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
				Model.Project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        public List<Model.Project> GetListByPage1(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage1(strWhere, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
