using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    /// <summary>
    /// EQP 接收请求 /- RECEIVE REQUEST
    /// </summary>
    public enum RECEIVE_REQUEST_TYPE
    {
        /// <summary>
        /// 同步设备时间 /-  machine sync time
        /// </summary>
        SyncTime = 0,

        /// <summary>
        /// 获取设备当前状态 /- Get the machine current status
        /// </summary>
        GetEqpStatu,

        /// <summary>
        /// 设备参数采集 /-
        /// </summary>
        EdcCollect,

        /// <summary>
        /// EAP 下发 Recipe 到设备 /- EAP issued Recipe to machine
        /// </summary>
        RecipeDownload,

        /// <summary>
        /// EAP 请求设备 Recipe Body /-  EAP request machine Recipe Body
        /// </summary>
        RecipeUpload,

        /// <summary>
        /// 设备控制：EAP 给设备下指令 /- Machine control : EAP give instructions to machine
        /// </summary>
        RemoteCommand
    }
}
