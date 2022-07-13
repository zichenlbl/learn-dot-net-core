using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Utils
{
    /// <summary>
    /// 前台Ajax请求的统一返回结果类
    /// </summary>
    public class Result
    {
        private Result()
        {

        }

        private ErrCode mErrCode = ErrCode.Success;
        /// <summary>
        /// 返回编码
        /// </summary>
        public ErrCode S_ErrCode { get { return mErrCode; } set { mErrCode = value; } }

        /// <summary>
        /// 错误信息，或者成功信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功可能时返回的数据
        /// </summary>
        public object Data { get; set; }

        #region Error
        public static Result Error()
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Err
            };
        }
        public static Result Error(string message)
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Err,
                Message = message
            };
        }

        public static Result Error(string message, ErrCode pErrCode)
        {
            return new Result()
            {
                S_ErrCode = pErrCode,
                Message = message
            };
        }
        #endregion

        #region Success
        public static Result Success()
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Success
            };
        }
        public static Result Success(string message)
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Success,
                Message = message
            };
        }
        public static Result Success(object data)
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Success,
                Data = data
            };
        }
        public static Result Success(object data, string message)
        {
            return new Result()
            {
                S_ErrCode = ErrCode.Success,
                Data = data,
                Message = message
            };
        }
        #endregion

        /// <summary>
        /// 错误类型
        /// </summary>
        public enum ErrCode
        {
            /// <summary>
            /// 正常
            /// </summary>
            Success = 0,
            /// <summary>
            /// 异常
            /// </summary>
            Err = -1,
            /// <summary>
            /// 令牌过期
            /// </summary>
            TokenExpired = -2,
            /// <summary>
            /// 令牌无效
            /// </summary>
            TokenInvalid = -3,
            /// <summary>
            /// 参数格式不正确
            /// </summary>
            ArgeFormatErr = -4,
            /// <summary>
            /// 服务器内部错误
            /// </summary>
            ServerErr = -100,
            /// <summary>
            /// 验证码错误
            /// </summary>
            CheckCodeErr = -5,
            /// <summary>
            /// 没有权限
            /// </summary>
            NoAuthority = -6
        }
    }
}
