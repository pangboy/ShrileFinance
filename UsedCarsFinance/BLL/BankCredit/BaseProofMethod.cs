namespace BLL.BankCredit
{
    /// <summary>
    /// 基础校验方法基类
    /// </summary>
    public class BaseProofMethod
    {
        /// <summary>
        /// 校验金额类型方法
        /// </summary>
        /// <returns></returns>
        public virtual bool ProofMoneyMethod()
        {
            return true;
        }

        /// <summary>
        /// 校验时间类型方法
        /// </summary>
        /// <returns></returns>
        public virtual bool ProofTimeMethod()
        {
            return true;
        }

        /// <summary>
        /// 校验计算类型方法
        /// </summary>
        /// <returns></returns>
        public virtual bool ProofReckonMethod()
        {
            return true;
        }

        /// <summary>
        /// 校验唯一性约束方法
        /// </summary>
        /// <returns></returns>
        public virtual bool ProofUniqueMethod()
        {
            return true;
        }
    }
}
