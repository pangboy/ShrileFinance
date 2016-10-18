using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Flow;
using Model.Finance;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using Model.Vehicle;

namespace BLL.Flow
{
    public class Instance
    {
        private readonly static DAL.Flow.InstanceMapper instanceMapper = new DAL.Flow.InstanceMapper();

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy     16.04.29
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public InstanceInfo Get(int instanceId)
        {
            return instanceMapper.Find(instanceId);
        }

        /// <summary>
        /// 添加流程实例
        /// </summary>
        /// qiy     16.04.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Add(InstanceInfo value)
        {
            instanceMapper.Insert(value);

            return value.InstanceId > 0;
        }

        /// <summary>
        /// 发起流程实例
        /// </summary>
        /// yaoy    16.07.26
        /// <returns></returns>
        public int StartProcess()
        {
            return new Engine().StartProcess();
        }

        /// <summary>
        /// 修改流程实例
        /// </summary>
        /// qiy     16.04.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(InstanceInfo value)
        {
            InstanceInfo instance = Get(value.InstanceId);

            if (instance == null) return false;

            instance.CurrentNode = value.CurrentNode;
            instance.CurrentUser = value.CurrentUser;
            instance.ProcessUser = value.ProcessUser;
            instance.ProcessTime = value.ProcessTime;
            instance.EndTime = value.EndTime;
            instance.Status = value.Status;

            return instanceMapper.Update(instance);
        }

        /// <summary>
        /// 更新草稿数据
        /// </summary>
        /// yaoy    16.07.25
        /// <param name="instanceId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ModifyTempData(int instanceId, string data)
        {
            return instanceMapper.ModifyTempData(instanceId, data) > 0;
        }

        /// <summary>
        /// 获取实例数据
        /// </summary>
        /// qiy     16.05.09
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public string GetData(int instanceId)
        {
            return instanceMapper.FindData(instanceId);
        }

        /// <summary>
        /// 获取实例数据
        /// </summary>
        /// qiy     16.05.04
        /// yaoy    16.07.27 (修改获取实例数据的方法)
        /// <typeparam name="AnonymousType">匿名类型</typeparam>
        /// <param name="instanceId">实例标识</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns></returns>
        public AnonymousType GetData<AnonymousType>(int instanceId, AnonymousType anonymousTypeObject)
        {
            var json = string.Empty;
            var xml = instanceMapper.FindXMLData(instanceId);

            if (xml != string.Empty)
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                json = JsonConvert.SerializeXmlNode(doc);
            }
           
            return Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(
                json,
                anonymousTypeObject
            );
        }

        /// <summary>
        /// 获取实例表XML对象数据
        /// </summary>
        /// yaoy    16.07.27
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public string GetXMLData(int instanceId)
        {
            var xml = instanceMapper.FindXMLData(instanceId);

            // 在发起流程后，流程未进行流转，则没有融资信息
            if(xml == string.Empty)
            {
                return null;
            }
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var json = JsonConvert.SerializeXmlNode(doc);

            return json;
        }

        /// <summary>
        /// 设置实例数据
        /// </summary>
        /// qiy     16.05.04
        /// yaoy    16.07.27(删除了InstanceData数据)
        /// <param name="instanceId">实例标识</param>
        /// <param name="value">数据</param>
        public void SetData(int instanceId, object value)
        {
            XmlDocument xml= JsonConvert.DeserializeXmlNode(Newtonsoft.Json.JsonConvert.SerializeObject(value));
            instanceMapper.UpdateData(instanceId, xml.InnerXml);
        }

      

        /// <summary>
        /// 查询代办列表
        /// </summary>
        /// yand    15.11.27
        /// qiy		16.03.08
        /// yand    16.07.25(添加主要信息字段)
        /// <param name="page"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public DataTable DoingList(Model.Pagination page, NameValueCollection filters)
        {
            var user = new User.User().CurrentUser();
            filters.Add("CurrentUser", user.UserId.ToString());
            filters.Add("CurrentRole", user.RoleId.ToString());

            DataTable dt = instanceMapper.FindDoingList(page, filters);
             dt.Columns.Add("MainInfo", Type.GetType("System.String"));
            //代办列表有值
            if (dt.Rows.Count > 0)
            {
                for(int i =0;i< dt.Rows.Count; i++)
                {
                    CarHomeInfo carHome = new CarHomeInfo();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["VehicleKey"].ToString()))
                    {

                        carHome = new DAL.Vehicle.CarHomeMapper().FindCarInfo(dt.Rows[i]["VehicleKey"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Name"].ToString()))
                    {
                        dt.Rows[i]["MainInfo"] = "客户姓名：" + dt.Rows[i]["Name"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["PlateNo"].ToString()))
                    {
                        dt.Rows[i]["MainInfo"] += "　车牌号：" + dt.Rows[i]["PlateNo"] ;
                    }
                    if (!string.IsNullOrEmpty(carHome.Vehicle))
                    {
                        dt.Rows[i]["MainInfo"] += "　车型：" + carHome.Vehicle;
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// 查询已办列表
        /// </summary>
        /// yand    15.11.27
        /// qiy		16.03.08
        /// yand    16.07.25(添加主要信息字段)
        /// <param name="page"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public DataTable DoneList(Model.Pagination page, NameValueCollection filters)
        {
            filters.Add("CurrentUser", User.User.CurrentUserId.ToString());
            CarHomeInfo carHome = new CarHomeInfo();
            DataTable dt = instanceMapper.FindDoneList(page, filters);
            dt.Columns.Add("MainInfo", Type.GetType("System.String"));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["VehicleKey"].ToString())){
                        carHome = new DAL.Vehicle.CarHomeMapper().FindCarInfo(dt.Rows[i]["VehicleKey"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Name"].ToString()))
                    {
                        dt.Rows[i]["MainInfo"] = "客户姓名：" + dt.Rows[i]["Name"];
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["PlateNo"].ToString()))
                    {
                        dt.Rows[i]["MainInfo"] += "　车牌号：" + dt.Rows[i]["PlateNo"];
                    }
                    if (!string.IsNullOrEmpty(carHome.Vehicle))
                    {
                        dt.Rows[i]["MainInfo"] += "　车型：" + carHome.Vehicle;
                    }
                }
            }
            return dt;
        }

    }
}
