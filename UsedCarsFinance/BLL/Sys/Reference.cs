using Models.Sys;

namespace BLL.Sys
{
    public class Reference
    {
        private readonly static DAL.Sys.ReferenceMapper referenceMapper = new DAL.Sys.ReferenceMapper();

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy		16.03.30
        /// <param name="referenceId">标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(int referenceId)
        {
            return referenceMapper.Find(referenceId);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy		16.03.30
        /// <param name="referencedId">被引用标识</param>
        /// <param name="referencedModule">被引用模块</param>
        /// <param name="referencedSid">被引用子标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(int? referencedId, int? referencedModule, int? referencedSid = null)
        {
            return referenceMapper.FindByReferenced(new ReferenceInfo
            {
                ReferencedId = referencedId,
                ReferencedModule = referencedModule,
                ReferencedSid = referencedSid
            });
        }

        /// <summary>
        /// 查找||申请一个引用
        /// </summary>
        /// qiy		16.03.30
        /// cais    16.05.05
        /// <param name="referencedId">被引用标识</param>
        /// <param name="referencedModule">被引用模块</param>
        /// <param name="referencedSid">被引用子标识</param>
        /// <returns></returns>
        public ReferenceInfo Apply(int? referencedId, int? referencedModule, int? referencedSid = null)
        {
            ReferenceInfo reference = Get(referencedId, referencedModule, referencedSid);

            if (reference == null)
            {
                referenceMapper.Insert(reference = new ReferenceInfo()
                {
                    ReferencedId = referencedId,
                    ReferencedModule = referencedModule,
                    ReferencedSid = referencedSid
                });
            }
            return reference;
        }

        /// <summary>
        /// 修改引用
        /// </summary>
        /// qiy		16.03.30
        /// <param name="value">值</param>
        /// <returns></returns>
        ///
        public bool Modify(ReferenceInfo value)
        {
            ReferenceInfo reference = Get(value.ReferenceId);

            if (reference == null) return false;

            reference.ReferencedId = value.ReferencedId;
            reference.ReferencedModule = value.ReferencedModule;
            reference.ReferencedSid = value.ReferencedSid;

            return referenceMapper.Update(reference) > 0;
        }
    }
}