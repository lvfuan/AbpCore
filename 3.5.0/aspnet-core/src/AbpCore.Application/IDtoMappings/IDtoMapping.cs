using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCore.IDtoMappings
{
/*=====================================

创建人：吕福安

创建时间：

=====================================*/

    /// <summary>
    ///     实现该接口以进行映射规则创建
    /// </summary>
    internal interface IDtoMapping
    {
        void CreateMapping(IMapperConfigurationExpression mapperConfig);
    }

}
