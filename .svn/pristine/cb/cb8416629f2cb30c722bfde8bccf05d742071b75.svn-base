using NWJ.Cmn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    /// <summary>
	/// t_user
	/// </summary>
	public partial class t_user
    {
        private readonly Dal.t_user dal = new Dal.t_user();
        public t_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.t_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.t_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.t_user GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.t_user GetModelss(string strwhere)
        {

            return dal.GetModelss(strwhere);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.t_user GetModelssss(string strwhere)
        {

            return dal.GetModelssss(strwhere);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.t_user GetModelsss(string strwhere)
        {

            return dal.GetModelsss(strwhere);
        }

        public Model.t_user GetModels() {
            return dal.GetModels();

        }


        public Model.t_user GetModelpwd(string username, string password, bool is_encrypt) {
            if (is_encrypt)
            {
                password = DESEncrypt.Encrypt(password);
            }
                return dal.GetModelpwd(username, password);
        }

        public Model.t_user GetUpdatepwd(string username)
        {

            return dal.GetUpdatepwd(username);
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
        public List<Model.t_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.t_user> GetModelLists(string strWhere)
        {
            DataSet ds = dal.GetLists(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.t_user> GetModelListss(string strWhere)
        {
            DataSet ds = dal.GetListss(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.t_user> DataTableToList(DataTable dt)
        {
            List<Model.t_user> modelList = new List<Model.t_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.t_user model;
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


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
