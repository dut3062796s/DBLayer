﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Common.Logging;
using System.Threading.Tasks;
using System.Reflection;
using DBLayer.Core.Interface;

namespace DBLayer.Persistence.Data
{
    /// <summary>
    /// 通用数据库提供类
    /// </summary>
    public class DbProvider : IDbProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQLPARAMETER = "?";
        #region 接口
        public string ProviderName { get; set; }
        private System.Data.Common.DbProviderFactory dbProviderFactory { get; set; }
        /// <summary>
        /// Parameter prefix use in store procedure.
        /// </summary>
        /// <example> @ for Sql Server.</example>
        public string ParameterPrefix { get; set; }
        public string SelectKey { get; set; }  
        public System.Data.Common.DbProviderFactory GetDbProviderFactory()
        {
            if (dbProviderFactory==null)
            {
                dbProviderFactory = DbProviderFactories.GetFactory(this.ProviderName);
            }
            return dbProviderFactory;
        }
        #endregion
    }
}
