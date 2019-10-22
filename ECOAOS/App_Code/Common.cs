using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using DataAccess.Operate;
using DataEntity;

using System.Data;
using System.IO;
using System.Net;
using System.ComponentModel;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region
    public static string getDocumentLink(string DocumentName, string ApplyDate)
    {
        if (string.IsNullOrEmpty(ApplyDate)) {
            ApplyDate = "1990-01-01";
        }
        string applypath = "", F_Model = "";
        switch (DocumentName)
        {
            case "(物业部/工商铺)IT权限申请表":
                applypath = "ITPower/Apply_ITPower_Detail";
                F_Model = "1";
                break;
            case "软件系统开发需求申请表":
                applypath = "SysReq/Apply_SysReq_Detail";
                F_Model = "5";
                break;
            case "(后勤/汇瀚/二级市场)IT权限申请表":
                applypath = "SysPower/Apply_SysPower_Detail";
                F_Model = "6";
                break;
            case "报废申请表":
                //if (DateTime.Parse(ApplyDate) > DateTime.Parse("2017-09-06 12:30:00.999"))
                //    applypath = "Scrap/New/Apply_Scrap_Detail";
                //else
                    applypath = "Scrap/Old/Apply_Scrap_Detail";

                F_Model = "7";
                break;
            case "资产调动表":
                //if (DateTime.Parse(ApplyDate) > DateTime.Parse("2017-09-06 12:30:00.999"))
                //    applypath = "AssetTransfer/New/Apply_AssetTransfer_Detail";
                //else
                    applypath = "AssetTransfer/Old/Apply_AssetTransfer_Detail";

                F_Model = "8";
                break;
            case "物业部成交商铺/写字楼备案申请表":
                applypath = "DealOffice/Apply_DealOffice_Detail";
                F_Model = "10";
                break;
            case "计算机及相关设备购买申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2015-12-07 12:30:00.999"))
                    applypath = "ITBuy/20151207/Apply_ITBuy_Detail";
                else
                    applypath = "ITBuy/Apply_ITBuy_Detail";

                F_Model = "11";
                break;
            case "员工个人利益申报表":
                applypath = "PersInterests/Apply_PersInterests_Detail";
                F_Model = "12";
                break;
            case "员工个人利益申报表 ":
                applypath = "PersInterests/Apply_NewPersInterests_Detail";
                F_Model = "53";
                break;
            case "员工购租楼宇申报及免佣福利申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.BUYBUILDING_OLD_TIME))
                    applypath = "BuyBuilding/Apply_NewBuyBuilding_Detail";
                else
                    applypath = "BuyBuilding/Apply_BuyBuilding_Detail";

                F_Model = "13";
                break;
            case "小汽车津贴申请表":
                applypath = "CarAllowance/Apply_CarAllowance_Detail";
                F_Model = "14";
                break;
            case "退佣申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "BackComm/Apply_BackComm_Detail";
                else
                    applypath = "Old/BackComm/Apply_BackComm_Detail";

                F_Model = "15";
                break;
            case "坏账申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "BadDebts/Apply_BadDebts_Detail";
                else
                    applypath = "Old/BadDebts/Apply_BadDebts_Detail";
                F_Model = "16";
                break;
            case "减让佣/现金奖申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.REDUCECOMM_OLD_TIME))
                    applypath = "ReduceComm/Apply_NewReduceComm_Detail";
                else
                    applypath = "ReduceComm/Apply_ReduceComm_Detail";
                F_Model = "17";
                break;
            case "项目费用申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "ProjCost/Apply_ProjCost_Detail";
                else
                    applypath = "Old/ProjCost/Apply_ProjCost_Detail";
                F_Model = "18";
                break;
            case "合作费申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "CoopCost/Apply_CoopCost_Detail";
                else
                    applypath = "Old/CoopCost/Apply_CoopCost_Detail";
                F_Model = "19";
                break;
            case "物业部承接项目报备申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2014-08-07 16:15:00.999"))
                    applypath = "UndertakeProj/Apply_NewUndertakeProj_Detail";
                else
                    applypath = "UndertakeProj/Apply_UndertakeProj_Detail";
                F_Model = "20";
                break;
            case "项目发展商额外奖金报备":
                applypath = "ExtraBonus/Apply_ExtraBonus_Detail";
                F_Model = "21";
                break;
            case "恢复营业申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "ResumeBusi/Apply_ResumeBusi_Detail";
                else
                    applypath = "Old/ResumeBusi/Apply_ResumeBusi_Detail";
                F_Model = "22";
                break;
            case "撤铺/转铺申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2015-11-12 23:59:59.999"))
                    applypath = "WithdrawShop/Apply_WithdrawShop_Detail";
                else
                    applypath = "WithdrawShop/Old/Apply_WithdrawShop_Detail";
                F_Model = "23";
                break;
            case "暂停营业申请表":
                //applypath = "SuspendBusi/Apply_SuspendBusi_Detail";
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2015-08-06"))
                {
                    if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                        applypath = "SuspendBusi/Apply_SuspendBusi_Detail";
                    else
                        applypath = "Old/SuspendBusi/Apply_SuspendBusi_Detail";
                }
                else
                    applypath = "SuspendBusi/Temp/Apply_SuspendBusi_Detail";
                F_Model = "24";
                break;
            case "项目销售代理合同条款申请表":
                applypath = "ProjAgentClause/Apply_ProjAgentClause_Detail";
                F_Model = "25";
                break;
            case "项目工衣申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "ProjWorkCloth/Apply_ProjWorkCloth_Detail";
                else
                    applypath = "Old/ProjWorkCloth/Apply_ProjWorkCloth_Detail";
                F_Model = "26";
                break;
            case "项目宿舍及津贴费用申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.EMMA_OLD_TIME))
                    applypath = "ProjDormSubsiby/Apply_ProjDormSubsiby_Detail";
                else
                    applypath = "Old/ProjDormSubsiby/Apply_ProjDormSubsiby_Detail";
                F_Model = "27";
                break;
            case "项目报数申请表":
                applypath = "ProjRepoData/Apply_ProjRepoData_Detail";
                F_Model = "28";
                break;
            case "项目联动报数申请表":
                applypath = "ProjLinkRepoData/Apply_ProjLinkRepoData_Detail";
                F_Model = "29";
                break;

            case "变更资料申请表":
                applypath = "ChangeData/Apply_ChangeData_Detail";
                F_Model = "30";
                break;
            case "应收佣金调整报告":
                applypath = "CommissionAdjust/Apply_CommissionAdjust_Detail";
                F_Model = "31";
                break;
            case "无线固话申请表":
                applypath = "WirelessFixedLine/Apply_WirelessFixedLine_Detail";
                F_Model = "32";
                break;
            case "进修津贴申请表":
                applypath = "FurtherEducation/Apply_FurtherEducation_Detail";
                F_Model = "33";
                break;
            case "特殊上数申请表":
                applypath = "SpecialNumber/Apply_SpecialNumber_Detail";
                F_Model = "34";
                break;
            case "公章使用申请表":
                applypath = "OfficialSeal/Apply_OfficialSeal_Detail";
                F_Model = "35";
                break;
            case "分行续约申请报告":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.BRANCHCONTRACT_OLD_TIME))
                    applypath = "BranchContract/Apply_NewBranchContract_Detail";
                else
                    applypath = "BranchContract/Apply_BranchContract_Detail";

                F_Model = "36";
                break;
            case "营运部门自组织外出活动申请":
                applypath = "Tourism/Apply_Tourism_Detail";
                F_Model = "37";
                break;
            case "延缓提交入职资料申请":
                applypath = "OweSubmit/Apply_OweSubmit_Detail";
                F_Model = "38";
                break;
            case "新分行总启费用申请表":
                applypath = "TotalRev/Apply_TotalRev_Detail";
                F_Model = "39";
                break;
            case "新建分行可行性报告":
                applypath = "Feasibility/Apply_Feasibility_Detail";
                F_Model = "40";
                break;
            case "物业部一手项目追佣申请表":
                applypath = "AfterCommission/Apply_AfterCommission_Detail";
                F_Model = "41";
                break;
            case "法律部追佣合作费处理申请":
                applypath = "LegalCommission/Apply_LegalCommission_Detail";
                F_Model = "42";
                break;
            case "通用申请表":
                applypath = "GeneralApply/Apply_GeneralApply_Detail";
                F_Model = "43";
                break;
            case "合同条款申请表":
                applypath = "ContractTerms/Apply_ContractTerms_Detail";
                F_Model = "44";
                break;
            case "超成数备案":
                applypath = "NetSign/Apply_NetSign_Detail";
                F_Model = "45";
                break;
            case "关于享受本月佣金按全年一次性奖金发放申请表":
                applypath = "CommissionOfMonth/Apply_CommissionOfMonth_Detail";
                F_Model = "46";
                break;
            case "市场推广费用申请":
                applypath = "Marketing/Apply_Marketing_Detail";
                F_Model = "47";
                break;
            case "资产借调申请表":
                applypath = "Secondment/Apply_Secondment_Detail";
                F_Model = "48";
                break;
            case "三级市场季会活动费用申请表":
                applypath = "CostOfActivity/Apply_CostOfActivity_Detail";
                F_Model = "49";
                break;
            case "项目部代理合同扣罚条款签名确认表":
                applypath = "PunishTerms/Apply_PunishTerms_Detail";
                F_Model = "50";
                break;
            case "网签变更、特殊申请表":
                applypath = "ChangeNS/Apply_ChangeNS_Detail";
                F_Model = "51";
                break;
            case "特殊个案申请表":
                applypath = "SpecialCase/Apply_SpecialCase_Detail";
                F_Model = "52";
                break;
            case "社保公积金特殊缴纳申请表":
                applypath = "SocialSecurity/Apply_SocialSecurity_Detail";
                F_Model = "54";
                break;
            //case "网络端口考核数据确认表":
            //    applypath = "PortAssessment/Apply_PortAssessment_Detail";
            //    F_Model = "55";
            //    break;
            case "小汽车津贴申请表（项目部）":
                applypath = "ProjectCarAllowance/Apply_ProjectCarAllowance_Detail";
                F_Model = "56";
                break;
            case "大额维修申请表":
                applypath = "Maintenance/Apply_Maintenance_Detail";
                F_Model = "57";
                break;
            case "新增、维修项目报价（结算）明细表":
                applypath = "Repair/Apply_Repair_Detail";
                F_Model = "58";
                break;
            case "广告宣传需求申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse(CommonConst.PROPAGANDA_OLD_TIME))
                    applypath = "Propaganda/Apply_NewPropaganda_Detail";
                else
                    applypath = "Propaganda/Apply_Propaganda_Detail";

                F_Model = "59";
                break;
            case "广告宣传预算使用异常申请表":
                applypath = "Budgetab/Apply_Budgetab_Detail";
                F_Model = "60";
                break;
            case "发展商额外奖金新增申请及调整申请":
                applypath = "EBAdjuct/Apply_EBAdjuct_Detail";
                F_Model = "61";
                break;
            case "担保申请":
                applypath = "Guarantee/Apply_Guarantee_Detail";
                F_Model = "62";
                break;
            case "关于签署两方版本担保协议书的申请":
                applypath = "SignedG/Apply_SignedG_Detail";
                F_Model = "63";
                break;
            case "三级市场一手项目欠必要性文件拉数申请":
                applypath = "PullafewRd/Apply_PullafewRd_Detail";
                F_Model = "64";
                break;
            case "二级市场一手项目欠必要性文件拉数申请":
                applypath = "PullafewTwo/Apply_PullafewTwo_Detail";
                F_Model = "65";
                break;
            case "物业部项目续约申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2015-10-28 23:50:00.999"))
                    applypath = "UndertakeProj/201510/Apply_UtContract_Detail";
                else
                    applypath = "UndertakeProj/201509/Apply_UtContract_Detail";
                F_Model = "66";
                break;
            case "物业部承接新项目申请表":
                if (DateTime.Parse(ApplyDate) > DateTime.Parse("2015-10-28 23:50:00.999"))
                    applypath = "UndertakeProj/201510/Apply_UtNewProj_Detail";
                else
                    applypath = "UndertakeProj/201509/Apply_UtNewProj_Detail";
                F_Model = "67";
                break;
            case "项目报数申请表(物业部加签)":
                applypath = "ProjReDaAdd/Apply_ProjReDaAdd_Detail";
                F_Model = "68";
                break;
            case "错存帐户调整申请表":
                applypath = "WrongSave/Apply_WrongSave_Detail";
                F_Model = "69";
                break;
            case "物业部购买楼盘资料申请":
                applypath = "BuyBudiData/Apply_BuyBudiData_Detail";
                F_Model = "70";
                break;
            case "项目部实收佣金调整申请表":
                applypath = "ProjBaComm/Apply_ProjBaComm_Detail";
                F_Model = "71";
                break;
            case "临时借用资金申请表":
                applypath = "BorrowMoney/Apply_BorrowMoney_Detail";
                F_Model = "72";
                break;
            case "特殊增编申请表":
                applypath = "SpecialAdd/Apply_SpecialAdd_Detail";
                F_Model = "73";
                break;
            case "薪酬福利类证明开具申请表":
                applypath = "OpenProve/Apply_OpenProve_Detail";
                F_Model = "74";
                break;
            case "项目部兼职申请":
                applypath = "PartTime/Apply_PartTime_Detail";
                F_Model = "75";
                break;
            case "申请内容修改申请表":
                applypath = "SysLogist/Apply_SysLogist_Detail";
                F_Model = "76";
                break;
            case "物业部批量解hold申请":
                applypath = "SolHold/Apply_SolHold_Detail";
                F_Model = "77";
                break;
            case "解除汇瀚HOLD佣申请":
                if (DateTime.Parse(ApplyDate) >= DateTime.Parse("2016-07-26"))
                {
                    applypath = "HoldCoisn/20160712/Apply_HoldCoisn_Detail";
                }
                else
                {
                    applypath = "HoldCoisn/Apply_HoldCoisn_Detail";
                }
                F_Model = "78";
                break;
            case "备案必须的内容":
                applypath = "Record/Apply_Record_Detail";
                F_Model = "79";
                break;
            case "新建呼叫中心可行性报告":
                applypath = "CallCenterFeasibility/Apply_CallCenterFeasibility_Detail";
                F_Model = "80";
                break;
            case "营业部自主招聘申请":
                applypath = "WYRecruit/Apply_WYRecruit_Detail";
                F_Model = "81";
                break;
            case "招聘需求申请":
                applypath = "Recruit/Apply_Recruit_Detail";
                F_Model = "82";
                break;
            case "项目部佣金分配指引":
                applypath = "CommissionAssign/Apply_CommissionAssign_Detail";
                F_Model = "83";
                break;
            case "公积金特殊申请表":
                applypath = "HousingFundChange/Apply_HousingFundChange_Detail";
                F_Model = "84";
                break;
            case "六级及以上营业人员入职资料核查表":
                applypath = "StaffDataCheck/Apply_StaffDataCheck_Detail";
                F_Model = "85";
                break;
            case "项目部通用申请":
                applypath = "ProjGeneralApply/Apply_ProjGeneralApply_Detail";
                F_Model = "86";
                break;
            case "CPN拍摄需求申请表":
                applypath = "CPNShoot/Apply_CPNShoot_Detail";
                F_Model = "87";
                break;
            case "公积金缴存比例年度调整申请表":
                applypath = "HousingFundAdjustment/Apply_HousingFundAdjustment_Detail";
                F_Model = "88";
                break;
            case "放款申请表":
                applypath = "Loan/Apply_Loan_Detail";
                F_Model = "89";
                break;
            case "软件系统特殊修改申请":
                applypath = "ITSpecialModify/Apply_ITSpecialModify_Detail";
                F_Model = "89";
                break;
            default:
                break;
        }
        return applypath + "|" + F_Model;
    }

    #endregion

    #region 发送提示信息
    ///// <summary>
    ///// 发送提示信息，包含发送邮件及MSN提醒。
    ///// </summary>
    ///// <returns></returns>
    //public static void SendMessage(string sMailTo, string sMailSubject, string sMailBody, string sMSNBody)
    //{
    //    try
    //    {
    //        SendMessage.LCSService LCSSendMessage = new SendMessage.LCSService();

    //        if (sMailTo.Length > 10)
    //        {
    //            SendEmail(sMailTo, sMailSubject, sMailBody);
    //            LCSSendMessage.SendMessage("CentaGZ07928E53-5228-457D-A586-2C67CF4F8017", sMailTo, sMailSubject, sMSNBody);
    //        }
    //    }
    //    catch
    //    { }
    //}

    ///// <summary>
    ///// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。
    ///// </summary>
    ///// <returns></returns>
    //public static void SendMessage(string sMailTo, string sMailSubject, string sMailBody, string sMSNBody)
    //{
    //    DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = sMailTo;

    //    DataAccess.Operate.DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DataAccess.Operate.DA_OfficeAutomation_Message_Inherit();
    //    da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
    //}

    /// <summary>
    /// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
    /// </summary>
    /// <param name="applyTableName">推送表名</param>
    /// <param name="sMailToUserName">发送姓名</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageEX(bool isa, string applyTableName, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody, string mainID)
    {
        if (sMailToUserName.Contains("陈洁丽（项目部）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if (sMailToUserName.Contains("陈洁丽（法律及客服）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（法律及客服）", "陈洁丽");
        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
        DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
        t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
        t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
        t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
        {
            try
            {
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationManager.AppSettings["TestEmail"].ToString();
                DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(sMailToUserName);
                //SendDirectPushMessageNew(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString(),sMailToUserName,sMailSubject,mainID); //手机推送
                SendDirectPushMessageNew(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString(), sMailToUserName, sMailSubject, mainID); //手机推送
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
            catch
            {
            }
        }
        else
        {
            string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, isa);
            string[] names = sMailToUserNames.Split(',');
            foreach (string name in names)
            {
                try
                {
                    t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                    DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(name);
                    SendDirectPushMessageNew(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString(), sMailToUserName, sMailSubject, mainID); //手机推送
                    da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
                }
                catch
                {
                }
            }
        }
    }

    /// <summary>
    /// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
    /// </summary>
    /// <param name="sMailToUserName">发送姓名</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageEX(bool isa, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
    {
        if (sMailToUserName.Contains("陈洁丽（项目部）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（项目部）", "陈洁丽A");
        else if (sMailToUserName.Contains("陈洁丽（法律及客服）"))
            sMailToUserName = sMailToUserName.Replace("陈洁丽（法律及客服）", "陈洁丽");
        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
        DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
        t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
        t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
        t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;

        if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
        {
            t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationManager.AppSettings["TestEmail"].ToString();

            da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
        }
        else
        {
            DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
            DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
            string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, isa);
            string[] names = sMailToUserNames.Split(',');
            foreach (string name in names)
            {
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
        }
    }

    public static void SendMessageEX(List<SendMes> list)
    {

    }

    #region 旧的推送消息并且手机推送   20170517更新新的推送消息之后注释
    //public static void SendMessageEX(bool isa, string applyTableName, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
    //{
    //    if (sMailToUserName.Contains("陈洁丽（项目部）"))
    //        sMailToUserName = sMailToUserName.Replace("陈洁丽（项目部）", "陈洁丽A");
    //    else if (sMailToUserName.Contains("陈洁丽（法律及客服）"))
    //        sMailToUserName = sMailToUserName.Replace("陈洁丽（法律及客服）", "陈洁丽");
    //    DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
    //    DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
    //    DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
    //    DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
    //    if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
    //    {
    //        try
    //        {
    //            t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationManager.AppSettings["TestEmail"].ToString();
    //            DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(sMailToUserName);
    //            SendDirectPushMessage(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString()); //手机推送
    //            da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
    //        }
    //        catch
    //        {
    //        }
    //    }
    //    else
    //    {
    //        string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserName, isa);
    //        string[] names = sMailToUserNames.Split(',');
    //        foreach (string name in names)
    //        {
    //            try
    //            {
    //                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
    //                DataSet ds = da_Employee_Inherit.GetEmployeeInfoByEmployeeNames(name);
    //                SendDirectPushMessage(applyTableName, ds.Tables[0].Rows[0]["Code"].ToString()); //手机推送
    //                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
    //            }
    //            catch
    //            {
    //            }
    //        }
    //    }
    //}
    #endregion

    ///// <summary>
    ///// 发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。（20131120 将代理人考虑其中。如果设置了代理人，则只发送给代理人邮件）
    ///// </summary>
    ///// <param name="sMailToUserID">发送工号</param>
    ///// <param name="sMailToUserName">发送姓名</param>
    ///// <param name="sMailSubject">主题</param>
    ///// <param name="sMailBody">邮件内容</param>
    ///// <param name="sMSNBody">内M内容</param>
    //public static void SendMessageEX(string sMailToUserID, string sMailToUserName, string sMailSubject, string sMailBody, string sMSNBody)
    //{
    //    DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
    //    DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
    //    t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;

    //    if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
    //    {
    //        t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationManager.AppSettings["TestEmail"].ToString(); ;

    //        da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
    //    }
    //    else {
    //        DA_OfficeAutomation_Agent_Inherit da_OfficeAutomation_Agent_Inherit = new DA_OfficeAutomation_Agent_Inherit();
    //        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
    //        string sMailToUserNames = da_OfficeAutomation_Agent_Inherit.SelectAgentByAuditor(sMailToUserID, sMailToUserName);
    //        string[] names = sMailToUserNames.Split(',');
    //        foreach (string name in names)
    //        {
    //            t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = da_Employee_Inherit.getDomainUserEmail(name);
    //            da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
    //        }
    //    }
    //}

    /// <summary>
    /// 根据邮件地址发送提示信息，包含发送邮件及MSN提醒，插入至通知信息表，延迟发送。
    /// </summary>
    /// <param name="applyTableName">推送表名</param>
    /// <param name="sMailAddress">收件地址</param>
    /// <param name="sMailSubject">主题</param>
    /// <param name="sMailBody">邮件内容</param>
    /// <param name="sMSNBody">内M内容</param>
    public static void SendMessageByEmailAddress(string applyTableName, string sMailAddress, string sMailSubject, string sMailBody, string sMSNBody)
    {

        DA_OfficeAutomation_Message_Inherit da_OfficeAutomation_Message_Inherit = new DA_OfficeAutomation_Message_Inherit();
        DataEntity.T_OfficeAutomation_Message t_OfficeAutomation_Message = new DataEntity.T_OfficeAutomation_Message();
        t_OfficeAutomation_Message.OfficeAutomation_Message_Title = sMailSubject;
        t_OfficeAutomation_Message.OfficeAutomation_Message_Body = sMailBody;
        t_OfficeAutomation_Message.OfficeAutomation_Message_MessBody = sMSNBody;
        DA_Employee_Inherit da_Employee_Inherit = new DA_Employee_Inherit();
        //string code;

        if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString() == "True")//如果在测试，则发送至开发人员邮箱
        {
            t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = System.Configuration.ConfigurationManager.AppSettings["TestEmail"].ToString();

            da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
        }
        else
        {
            string[] addresses = sMailAddress.Split('|');
            foreach (string address in addresses)
            {
                //code = da_Employee_Inherit.getUserNameByEmail(address);
                //if (code == "")
                //    code = da_Employee_Inherit.getSTByEmail(address);
                //SendDirectPushMessage(applyTableName, code); //手机推送
                t_OfficeAutomation_Message.OfficeAutomation_Message_ToEmail = address;
                da_OfficeAutomation_Message_Inherit.Insert(t_OfficeAutomation_Message);
            }
        }
    }

    #endregion

    #region 本地smtp发送Email
    /// <summary>
    /// 本地smtp发送Email
    /// </summary>
    /// <param name="MailTo">接收Email地址</param>
    /// <param name="MailFrom">发送翻Email地址</param>
    /// <param name="MailSubject">邮件主题</param>
    /// <param name="MailBody">邮件内容</param>
    /// <param name="isHtml">是否为Html格式</param>
    /// <returns>布尔值表示发送成功与否</returns>
    public static bool SendEmail(string MailTo, string MailSubject, string MailBody)
    {
        string MailFrom = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();
        MailMessage myMail = new MailMessage(MailFrom, MailTo);
        SmtpClient smtp = new SmtpClient();
        bool isReturn = false;

        try
        {
            myMail.BodyEncoding = Encoding.GetEncoding("utf-8");
            myMail.IsBodyHtml = Convert.ToBoolean("True");
            myMail.Subject = MailSubject;
            myMail.Body = MailBody;
            myMail.Priority = MailPriority.High;
            smtp.Host = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();

            smtp.Send(myMail);

            isReturn = true;
        }
        catch
        {
        }

        return isReturn;

    }
    #endregion

    #region 新增日志
    /// <summary>
    /// 新增日志
    /// </summary>
    /// <param name="sOperateID">操作人工号</param>
    /// <param name="sOperate">操作人</param>
    /// <param name="iModuleID">操作模块ID</param>
    /// <param name="gModuleMainID">操作模块主键</param>
    /// <param name="iOperateID">操作方式ID</param>
    /// /// <param name="sOperateDesc">操作记录</param>
    /// <returns></returns>
    public static bool AddLog(String sOperateID, string sOperate, int iModuleID, Guid gModuleMainID, int iOperateID)
    {
        bool isReturn = false;
        DataEntity.T_OfficeAutomation_Log Log = new DataEntity.T_OfficeAutomation_Log();
        DataAccess.Operate.DA_OfficeAutomation_Log_Operate Log_Operate = new DataAccess.Operate.DA_OfficeAutomation_Log_Operate();

        try
        {
            Log.OfficeAutomation_Log_EmployeeID = sOperateID;
            Log.OfficeAutomation_Log_EmployeeName = sOperate;
            Log.OfficeAutomation_Log_OperateID = iOperateID;
            Log.OfficeAutomation_Log_OperateModuleID = iModuleID;
            Log.OfficeAutomation_Log_OperateModuleMainID = gModuleMainID;
            Log.OfficeAutomation_Log_OperateTime = DateTime.Now;
            Log.OfficeAutomation_Log_OperateDesc = "";

            Log_Operate.Insert(Log);

            isReturn = true;
        }
        catch
        {

        }
        finally
        {
            Log_Operate = null;
        }

        return isReturn;
    }
    #endregion

    #region

    /// <summary>
    /// 通过departmentid获得该部门或组别的人事树架构
    /// 输入参数格式"departmentid=ae9c9858-830f-493e-94c4-90e31ec5bed6"
    /// 输出结果格式"26242,3189,3808|张榕,何旭晖,何智峰"
    /// </summary>
    /// <param name="context"></param>
    public static string GetHRTreeByDepartmentID(string departmentid)
    {
        string units = "", unitids = "";
        wsFinance.Service wsf = new wsFinance.Service();
        System.Data.DataSet ds = wsf.GetHRStructure(departmentid, DateTime.Now.ToString("yyyy-MM-dd"));
        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            units = ds.Tables[0].Rows[0]["HRStructure_Unit"].ToString().Replace('/', ',');
            unitids = ds.Tables[0].Rows[0]["HRStructure_UnitID"].ToString().Replace('/', ',');
            return unitids + "|" + units;
        }
        else
        {
            wsHR.HR wshr = new wsHR.HR();
            units = wshr.GetDepartmentManager(departmentid);
            if (string.IsNullOrEmpty(units))
            {
                return "fail";
            }
            else
            {
                unitids = wshr.GetDepartmentManagerCode(departmentid);
                return unitids + "|" + units;
            }
        }
    }

    #endregion

    #region 移动设备推送通知

    /// <summary>
    /// 推送手机通知审批人 2014-05-21
    /// </summary>
    /// <param name="code"></param>
    /// <param name="documentName"></param>
    public static void SendDirectPushMessage(string documentName, string code)
    {
        string[] employids = code.Split(',');
        for (int n = 0; n < employids.Length; n++)
        {
            SendDirectPushMessageByEmpCodeAndApplyName(documentName, employids[n]);
        }
    }

    /// <summary>
    /// 以工号消息直推
    /// </summary>
    /// <param name="applyTableName">申请表中文名</param>
    /// <param name="empCode">接收员工号</param>
    /// <returns></returns>
    public static string SendDirectPushMessageByEmpCodeAndApplyName(string applyTableName, string empCode)
    {
        string jsonData = "{\"table_name\":\"" + applyTableName + "\"}";
        return SendDirectPushMessageByEmpCode(jsonData, empCode);
    }

    /// <summary>
    /// 以工号消息直推
    /// </summary>
    /// <param name="pushId">mcoa提供的固定推送id</param>
    /// <param name="jsonData">推送参数json结构</param>
    /// <param name="empCode">接收员工号</param>
    /// <returns></returns>
    public static string SendDirectPushMessageByEmpCode(string jsonData, string empCode)
    {
        MCOAWS.McoaWS ws = new MCOAWS.McoaWS();
        if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"] == "True")
            empCode = System.Configuration.ConfigurationManager.AppSettings["TesterCode"];
        string s = ws.SendDirecePushMessageByEmpCode(System.Configuration.ConfigurationManager.AppSettings["PushID"], jsonData, empCode);
        return s;
    }

    public static string PushByDelete(string TName, string SerNo, string Apply, string empCode)
    {
        string jsonData = "{\"table_name\":\"" + TName + "\",\"SerNo\":\"" + SerNo + "\",\"Apply\":\"" + Apply + "\"}";
        MCOAWS.McoaWS ws = new MCOAWS.McoaWS();
        //if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"] == "True")
        //    empCode = System.Configuration.ConfigurationManager.AppSettings["TesterCode"];
        string s = ws.SendDirecePushMessageByEmpCode(System.Configuration.ConfigurationManager.AppSettings["PushDelID"], jsonData, empCode);
        return s;
    }

    #endregion

    #region 移动设备推送通知新20170509
    public static void SendDirectPushMessageNew(string documentName, string code, string empname, string title, string mainid)
    {
        DA_OfficeAutomation_Flow_Inherit flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        string url = "https://mcoa.gzcentaline.com.cn/McoaThirdPartAccess/McoaThirdPartAccess/sendTodo?accessKey=123456&appKey=系统秘书";
        string summary = "您好，" + empname + "：您有[" + documentName + "]需要审批。";

        string tablename = flow_Inherit.GetTableNameByMainID(mainid);
        int lastindex = tablename.LastIndexOf("_") + 1;
        string subname = tablename.Substring(lastindex, tablename.Length - lastindex);

        List<Events> eventslist = new List<Events>();
        Events events = new Events();
        events.title = title;
        events.summary = summary;
        events.scheme = "module=1&fReportId=" + mainid + "&tableName=" + subname + "&empcode=" + code + "&documentname=" + documentName;
        events.eventId = "1";
        events.param = "";
        eventslist.Add(events);

        SendTodo sendto = new SendTodo();
        sendto.empCode = code;
        //sendto.appid = "mcoa_ecoa_ark_beta";
        sendto.appid = "mcoa_approval";
        sendto.appid_ios = "";
        sendto.appName = "电子审批";
        sendto.appType = "1";
        sendto.events = eventslist;

        //发送消息
        ProcessPost(url, Newtonsoft.Json.JsonConvert.SerializeObject(sendto));
    }
    #endregion

    #region 根据mainid返回审核人，登录人如果是审核人的话才会显示上传附件按钮，反之不显示
    public static bool IsShowBtnUpload(string empcode, string MainID)
    {
        string flowEmpId = "";

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inheritz = new DA_OfficeAutomation_Flow_Inherit();
        DataSet dsflow = da_OfficeAutomation_Flow_Inheritz.SelectByMainID(MainID);

        for (int i = 0; i < dsflow.Tables[0].Rows.Count; i++)
        {
            string[] empidarr = dsflow.Tables[0].Rows[i]["OfficeAutomation_Flow_EmployeeID"].ToString().Split(',');
            for (int j = 0; j < empidarr.Length; j++)
            {
                flowEmpId += empidarr[j] + ",";
            }

        }

        flowEmpId = flowEmpId.Substring(0, flowEmpId.Length - 1);

        if (flowEmpId.Contains(empcode))
        {
            return true;
        }
        return false;

    }
    #endregion

    //20160330
    /// <summary>
    /// SaveFile是否存在
    /// </summary>
    /// <param name="pagename">页面名称</param>
    /// <param name="mainid"></param>
    /// <returns></returns>
    public string HasTempSaveFile(string pagename, string filename, string mainid)
    {
        try
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["TempSaveFilesURL"].ToString();
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("error:Common:HasTempSave:AppSettings TempSaveFilesURL is null");
            }
            path = path + pagename + "/" + filename + "_" + mainid + ".xml";
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                return path;
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("error:Common:HasTempSave:" + ex.Message);
        }
    }

    /// <summary>
    /// 反序列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T GetTempSaveEntity<T>(string path)
    {
        try
        {
            return XmlHelper.XmlDeserializeFromFile<T>(path, Encoding.UTF8);   //反序列化xml
        }
        catch (Exception ex)
        {
            throw new Exception("error:Common:GetTempSaveEntity:" + ex.Message);
        }
    }

    public T GetTempSaveEntity<T>(string pagename, string filename, string serialnumber)
    {
        string path = System.Configuration.ConfigurationManager.AppSettings["TempSaveFilesURL"].ToString().Replace("\\", "\\\\");
        path = path + pagename + "\\\\" + filename + "_" + serialnumber + ".xml";
        if (!File.Exists(path))
        {
            throw new Exception("xml is not exists");
        }
        return GetTempSaveEntity<T>(path);
    }

    public bool SaveTempSaveFile<T>(T obj, string pagename, string filename, string serialnumber)
    {
        try
        {
            var result = true;
            string path = System.Configuration.ConfigurationManager.AppSettings["TempSaveFilesURL"].ToString().Replace("\\", "\\\\");
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("error:Common:SaveTempSaveFile:AppSettings TempSaveFilesURL is null");
            }
            var pathdirectory = path + pagename + "\\\\";
            if (!Directory.Exists(pathdirectory))
                Directory.CreateDirectory(pathdirectory);
            path = path + pagename + "\\\\" + filename + "_" + serialnumber + ".xml";
            XmlHelper.XmlSerializeToFile(obj, path, Encoding.UTF8);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("error:Common:SaveTempSaveFile:" + ex.Message);
        }
    }

    //
    public static DataSet GetPageDetailDS<T>(T obj, DataEntity.T_OfficeAutomation_Main mainobj)
    {
        List<T> list = new List<T>();
        list.Add(obj);
        var ds = ECOA.Common.SerializationHelper.FillDataTable<T>(list);

        ds.Tables[0].Columns.Add("OfficeAutomation_SerialNumber", typeof(System.String));
        ds.Tables[0].Columns.Add("OfficeAutomation_Main_FlowStateID", typeof(System.String));

        ds.Tables[0].Rows[0]["OfficeAutomation_SerialNumber"] = mainobj.OfficeAutomation_SerialNumber;
        ds.Tables[0].Rows[0]["OfficeAutomation_Main_FlowStateID"] = mainobj.OfficeAutomation_Main_FlowStateID.ToString();

        return ds;
    }

    public static DataSet GetDataSet<T>(T obj) where T : class
    {
        var dt = ECOA.Common.SerializationHelper.CreateDataTable<T>(obj);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        ds.AcceptChanges();
        return ds;
    }

    public static DataSet GetDataSet<T>(List<T> list) where T : class
    {
        return ECOA.Common.SerializationHelper.FillDataTable<T>(list);
    }

    public struct AreaValue
    {
        //非营业部
        public static readonly string feiyingye = "KD01.0001.0002";
        //非营业部营运支持中心
        public static readonly string yingyunzhichi = "KD01.0001.0002.0033.0004";
        //项目部
        public static readonly string xiangmubu = "KD01.0001.0001.0002";
        //物业部（大海珠区、大越秀区、番禺一部）、汇瀚、广州市汇瀚有限公司
        public static readonly string wuye1 = "KD01.0001.0001.0001.0047.0001,KD01.0001.0001.0001.0035,KD01.0001.0001.0001.0015.0003,KD01.0001.0001.0001.0047.0004,KD01.0001.0001.0001.0047.0005,KD01.0001.0003,KD01.0007";
        //物业部（大天河区、大白云区、花都区、工商铺一、二部）
        public static readonly string wuye2 = "KD01.0001.0001.0001.0047.0002,KD01.0001.0001.0001.0047.0003,KD01.0001.0001.0001.0040,KD01.0001.0001.0001.0039,KD01.0001.0001.0001.0032,KD01.0001.0001.0001.0047.0006,KD01.0001.0001.0001.0015.0001,KD01.0001.0001.0001.0015.0002,KD01.0001.0001.0003";
    }

    //是否存在某个区域
    public static bool isExitsArea(string areavalueenum, string deptcode)
    {
        string[] arrs = areavalueenum.Split(',');
        for (int i = 0; i < arrs.Length; i++)
        {
            if (deptcode.IndexOf(arrs[i]) > -1)
            {
                return true;
            }
        }
        return false;
    }

    public static string ProcessPost(string url, string param)
    {
        try
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            Encoding encoding = Encoding.UTF8;
            //encoding.GetBytes(postData);
            byte[] bs = Encoding.UTF8.GetBytes(param);

            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/json;charset=UTF-8";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                    return responseData;
                }

            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    //推送手机端信息需要的类
    public class SendTodo
    {
        /// <summary>
        /// 推送的员工工号
        /// </summary>
        public string empCode { get; set; }

        /// <summary>
        /// 考勤系统： mcoa_onduty_ark; 电子审批: mcoa_ecoa_ark_beta; CCHR:mcoa_cchr_ark
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 填空值
        /// </summary>
        public string appid_ios { get; set; }

        /// <summary>
        /// 考勤系统; 电子审批; CCHR
        /// </summary>
        public string appName { get; set; }

        /// <summary>
        /// 填 1
        /// </summary>
        public string appType { get; set; }

        public IList<Events> events { get; set; }
    }

    public class Events
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// 前端页面跳转参数，请与前端同事询问，列如：module=1&username=工号
        /// </summary>
        public string scheme { get; set; }

        /// <summary>
        /// 填 1
        /// </summary>
        public string eventId { get; set; }

        /// <summary>
        /// 填空值
        /// </summary>
        public string param { get; set; }
    }

    #region 返回不同的list
    public static List<RentHouse> ReturnRentHouseListByType(DataTable dt)
    {
        List<RentHouse> rentHouseList = new List<RentHouse>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            RentHouse renthouse = new RentHouse();
            renthouse.empcode = dt.Rows[i][0].ToString();
            renthouse.empname = dt.Rows[i][1].ToString();
            renthouse.dept = dt.Rows[i][2].ToString();
            renthouse.depttypename = dt.Rows[i][3].ToString();
            renthouse.applydate = dt.Rows[i][4].ToString();
            renthouse.create = dt.Rows[i][5].ToString();
            renthouse.createdate = dt.Rows[i][6].ToString();
            renthouse.dealkind = dt.Rows[i][7].ToString();
            renthouse.dealproperty = dt.Rows[i][8].ToString();
            renthouse.flowcode = dt.Rows[i][9].ToString();
            renthouse.flowname = dt.Rows[i][10].ToString();
            renthouse.flowdept = dt.Rows[i][11].ToString();
            renthouse.propertyhander = dt.Rows[i][12].ToString();
            renthouse.building = dt.Rows[i][13].ToString();
            renthouse.anothersummary = dt.Rows[i][14].ToString();
            rentHouseList.Add(renthouse);
        }
        return rentHouseList;


    }
    public static List<FamilyRelation> ReturnFRListByType(DataTable dt)
    {
        List<FamilyRelation> familyRelationList = new List<FamilyRelation>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            FamilyRelation familyrelation = new FamilyRelation();
            familyrelation.empcode = dt.Rows[i][0].ToString();
            familyrelation.empname = dt.Rows[i][1].ToString();
            familyrelation.dept = dt.Rows[i][2].ToString();
            familyrelation.depttypename = dt.Rows[i][3].ToString();
            familyrelation.applydate = dt.Rows[i][4].ToString();
            familyrelation.create = dt.Rows[i][5].ToString();
            familyrelation.createdate = dt.Rows[i][6].ToString();
            familyrelation.relativesname = dt.Rows[i][7].ToString();
            familyrelation.relativedept = dt.Rows[i][8].ToString();
            familyrelation.position = dt.Rows[i][9].ToString();
            familyrelation.relationship = dt.Rows[i][10].ToString();
            familyrelation.anothersummary = dt.Rows[i][11].ToString();
            familyRelationList.Add(familyrelation);
        }

        return familyRelationList;

    }
    public static List<LiWu> ReturnLiWuListByType(DataTable dt)
    {
        List<LiWu> liwuList = new List<LiWu>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            LiWu liwu = new LiWu();
            liwu.empcode = dt.Rows[i][0].ToString();
            liwu.empname = dt.Rows[i][1].ToString();
            liwu.dept = dt.Rows[i][2].ToString();
            liwu.depttypename = dt.Rows[i][3].ToString();
            liwu.applydate = dt.Rows[i][4].ToString();
            liwu.create = dt.Rows[i][5].ToString();
            liwu.createdate = dt.Rows[i][6].ToString();
            liwu.applysomething = dt.Rows[i][7].ToString();
            liwu.giverorcompany = dt.Rows[i][8].ToString();
            liwu.anothersummary = dt.Rows[i][9].ToString();
            liwuList.Add(liwu);
        }
        return liwuList;

    }
    public static List<CommercialActivities> ReturnCAListByType(DataTable dt)
    {
        List<CommercialActivities> commercialActivitiesList = new List<CommercialActivities>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CommercialActivities commercialActivities = new CommercialActivities();
            commercialActivities.empcode = dt.Rows[i][0].ToString();
            commercialActivities.empname = dt.Rows[i][1].ToString();
            commercialActivities.dept = dt.Rows[i][2].ToString();
            commercialActivities.depttypename = dt.Rows[i][3].ToString();
            commercialActivities.applydate = dt.Rows[i][4].ToString();
            commercialActivities.create = dt.Rows[i][5].ToString();
            commercialActivities.createdate = dt.Rows[i][6].ToString();
            commercialActivities.entrust = dt.Rows[i][7].ToString();
            commercialActivities.buildingkind = dt.Rows[i][8].ToString();
            commercialActivities.flowcode = dt.Rows[i][9].ToString();
            commercialActivities.flowname = dt.Rows[i][10].ToString();
            commercialActivities.flowdept = dt.Rows[i][11].ToString();
            commercialActivities.anothersummary = dt.Rows[i][12].ToString();
            commercialActivitiesList.Add(commercialActivities);
        }
        return commercialActivitiesList;

    }
    public static List<PartTiemJob> ReturnPartTimeJobListByType(DataTable dt)
    {
        List<PartTiemJob> partTiemJobList = new List<PartTiemJob>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            PartTiemJob partTiemJob = new PartTiemJob();
            partTiemJob.empcode = dt.Rows[i][0].ToString();
            partTiemJob.empname = dt.Rows[i][1].ToString();
            partTiemJob.dept = dt.Rows[i][2].ToString();
            partTiemJob.depttypename = dt.Rows[i][3].ToString();
            partTiemJob.applydate = dt.Rows[i][4].ToString();
            partTiemJob.create = dt.Rows[i][5].ToString();
            partTiemJob.createdate = dt.Rows[i][6].ToString();
            partTiemJob.anotheractivity = dt.Rows[i][7].ToString();
            partTiemJob.investment = dt.Rows[i][8].ToString();
            partTiemJob.ipossitio = dt.Rows[i][9].ToString();
            partTiemJob.anothersummary = dt.Rows[i][10].ToString();
            partTiemJobList.Add(partTiemJob);
        }
        return partTiemJobList;
    }

    public static List<LoanWrongSave> ReturnLoanWrongSave(DataTable dt)
    {

    
        List<LoanWrongSave> rentHouseList = new List<LoanWrongSave>();
        decimal Total = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            LoanWrongSave renthouse = new LoanWrongSave();
            int b = dt.Columns.Count;
            renthouse.Number = "";
            renthouse.BranchName = dt.Rows[i][0].ToString();
            renthouse.PayeeName = dt.Rows[i][1].ToString();
            renthouse.PayeeNum = dt.Rows[i][2].ToString();
            renthouse.Money = decimal.Parse(dt.Rows[i][3].ToString());
            renthouse.PayeeBankName = dt.Rows[i][4].ToString();
            renthouse.SerialNumber = dt.Rows[i][6].ToString();
            rentHouseList.Add(renthouse);
            Total = Total + renthouse.Money;
        }
        rentHouseList = rentHouseList.OrderBy(p => p.Money).ToList();
        LoanWrongSave renthouseTotal = new LoanWrongSave();

        renthouseTotal.BranchName = "合计";
        renthouseTotal.PayeeName ="";
        renthouseTotal.PayeeNum = "";
        renthouseTotal.Money = Total;
        renthouseTotal.PayeeBankName ="";
        renthouseTotal.SerialNumber ="";
        rentHouseList.Add(renthouseTotal);
        return rentHouseList;


    }
    #endregion


    #region 根据不同的类型返回不同的数组
    public static string[] ReturnarrByType(int type)
    {

        if (type == 7)
        {
            string[] headnames = { "empcode", "empname", "dept", "depttypename", "applydate", "create", "createdate", "dealkind", "dealproperty", "flowcode", "flowname", "flowdept", "propertyhander", "building", "anothersummary" };
            return headnames;
        }
        else if (type == 8)
        {
            string[] headnames = { "empcode", "empname", "dept", "depttypename", "applydate", "create", "createdate", "relativesname", "relativedept", "position", "relationship", "anothersummary" };
            return headnames;
        }
        else if (type == 9)
        {
            string[] headnames = { "empcode", "empname", "dept", "depttypename", "applydate", "create", "createdate", "applysomething", "giverorcompany", "anothersummary" };
            return headnames;
        }
        else if (type == 10)
        {
            string[] headnames = { "empcode", "empname", "dept", "depttypename", "applydate", "create", "createdate", "entrust", "buildingkind", "flowcode", "flowname", "flowdept", "anothersummary" };
            return headnames;
        }
        else
        {
            string[] headnames = { "empcode", "empname", "dept", "depttypename", "applydate", "create", "createdate", "anotheractivity", "investment", "ipossitio", "anothersummary" };
            return headnames;
        }
    }
    #endregion

    #region 根据类型导出员工个人利益申报表需要的类
    public class RentHouse
    {
        [Description("申请人工号")]
        public string empcode { get; set; }
        [Description("申请人姓名")]
        public string empname { get; set; }
        [Description("部门分行")]
        public string dept { get; set; }
        [Description("部门性质")]
        public string depttypename { get; set; }
        [Description("申请日期")]
        public string applydate { get; set; }
        [Description("填表人")]
        public string create { get; set; }
        [Description("填表日期")]
        public string createdate { get; set; }
        [Description("交易类型")]
        public string dealkind { get; set; }
        [Description("交易类别")]
        public string dealproperty { get; set; }
        [Description("跟进人工号")]
        public string flowcode { get; set; }
        [Description("跟进人姓名")]
        public string flowname { get; set; }
        [Description("跟进人分行")]
        public string flowdept { get; set; }
        [Description("业权人")]
        public string propertyhander { get; set; }
        [Description("物业地址")]
        public string building { get; set; }
        [Description("其他情况申报")]
        public string anothersummary { get; set; }
    }

    public class FamilyRelation
    {
        [Description("申请人工号")]
        public string empcode { get; set; }
        [Description("申请人姓名")]
        public string empname { get; set; }
        [Description("部门分行")]
        public string dept { get; set; }
        [Description("部门性质")]
        public string depttypename { get; set; }
        [Description("申请日期")]
        public string applydate { get; set; }
        [Description("填表人")]
        public string create { get; set; }
        [Description("填表日期")]
        public string createdate { get; set; }
        [Description("亲属姓名")]
        public string relativesname { get; set; }
        [Description("所在部门")]
        public string relativedept { get; set; }
        [Description("担任职位")]
        public string position { get; set; }
        [Description("亲属关系")]
        public string relationship { get; set; }
        [Description("其他情况申报")]
        public string anothersummary { get; set; }
    }

    public class LiWu
    {
        [Description("工号")]
        public string empcode { get; set; }
        [Description("姓名")]
        public string empname { get; set; }
        [Description("部门分行")]
        public string dept { get; set; }
        [Description("部门性质")]
        public string depttypename { get; set; }
        [Description("申请日期")]
        public string applydate { get; set; }
        [Description("填表人")]
        public string create { get; set; }
        [Description("填表日期")]
        public string createdate { get; set; }
        [Description("申请事项")]
        public string applysomething { get; set; }
        [Description("赠送人/单位")]
        public string giverorcompany { get; set; }
        [Description("其他情况申报说明")]
        public string anothersummary { get; set; }
    }

    public class CommercialActivities
    {
        [Description("申请人工号")]
        public string empcode { get; set; }
        [Description("申请人姓名")]
        public string empname { get; set; }
        [Description("部门分行")]
        public string dept { get; set; }
        [Description("部门性质")]
        public string depttypename { get; set; }
        [Description("申请日期")]
        public string applydate { get; set; }
        [Description("填表人")]
        public string create { get; set; }
        [Description("填表日期")]
        public string createdate { get; set; }
        [Description("委托公司代理中介服务")]
        public string entrust { get; set; }
        [Description("物业类型")]
        public string buildingkind { get; set; }
        [Description("跟进人工号")]
        public string flowcode { get; set; }
        [Description("跟进人姓名")]
        public string flowname { get; set; }
        [Description("跟进人分行")]
        public string flowdept { get; set; }
        [Description("其他情况申报")]
        public string anothersummary { get; set; }
    }

    public class PartTiemJob
    {
        [Description("申请人工号")]
        public string empcode { get; set; }
        [Description("申请人姓名")]
        public string empname { get; set; }
        [Description("部门分行")]
        public string dept { get; set; }
        [Description("部门性质")]
        public string depttypename { get; set; }
        [Description("申请日期")]
        public string applydate { get; set; }
        [Description("填表人")]
        public string create { get; set; }
        [Description("填表日期")]
        public string createdate { get; set; }
        [Description("申请事项")]
        public string anotheractivity { get; set; }
        [Description("投资或兼职公司名称")]
        public string investment { get; set; }
        [Description("投资或兼职职位")]
        public string ipossitio { get; set; }
        [Description("其他情况申报")]
        public string anothersummary { get; set; }
    }

    public class LoanWrongSave
    {
        [Description("序号")]
        public string Number { get; set; }
        [Description("分行")]
        public string BranchName { get; set; }
        [Description("收款人")]
        public string PayeeName { get; set; }
        [Description("帐号")]
        public string PayeeNum { get; set; }
        [Description("金额")]
        public decimal Money { get; set; }
        [Description("开户行")]
        public string PayeeBankName { get; set; }
        [Description("交易编号")]
        public string SerialNumber { get; set; }
    }
    #endregion

    private static string _loginName = "LoginUser";
    public static void SignIn(UserInfo userData, int expiration, string purview)
    {
        string str = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
        var list = GetPurview(purview, userData.AdminSearch);
        str = ECOA.Common.Secruity.Encrypt(str);
        ECOA.Common.Cookie.SaveCookie(_loginName, str, expiration);
        ECOA.Common.Cookie.SaveCookie("Purview", purview, expiration);
        ECOA.Common.Cookie.SaveCookie("DocIDs", list[0] + "|" + list[1], expiration);
    }

    public static UserInfo GetLoginUser()
    {
        string userstr = ECOA.Common.Cookie.GetCookie(_loginName);
        string purview = ECOA.Common.Cookie.GetCookie("Purview");
        string docids = ECOA.Common.Cookie.GetCookie("DocIDs");
        if (string.IsNullOrEmpty(userstr) || string.IsNullOrEmpty(purview) || string.IsNullOrEmpty(docids))
        {
            return null;
        }
        try
        {
            userstr = ECOA.Common.Secruity.Decrypt(userstr);
            UserInfo user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(userstr);
            user.Purview = purview;
            user.DocIDs = docids;
            return user;
        }
        catch
        {
            return null;
        }
    }

    private void LogOut()
    {
        try
        {
            ECOA.Common.Cookie.ClearCookie("LoginUser");
            ECOA.Common.Cookie.ClearCookie("Purview");
            ECOA.Common.Cookie.ClearCookie("DocIDs");
        }
        catch
        { }
    }

    private static List<string> GetPurview(string purview, bool bIsAdminSearch)
    {
        string sl = "";     //有权限访问的IDs
        string snl = "";    //无权限访问的IDs
        List<string> result = new List<string>();

        DataAccess.Operate.DA_Dic_OfficeAutomation_Document_Inherit bll = new DA_Dic_OfficeAutomation_Document_Inherit();
        var list = bll.SelectAllListInCache();

        //没有任何权限
        if (string.IsNullOrEmpty(purview))
        {
            foreach (var l in list)
            {
                snl += l.OfficeAutomatifon_Document_ID.ToString() + ",";
            }
            result.Add(sl);
            result.Add(snl);
            return result;
        }

        //“管理员搜索”有所有申请的查看权限
        if (bIsAdminSearch)
        {
            foreach (var l in list)
            {
                sl += l.OfficeAutomatifon_Document_ID.ToString() + ",";
            }
            result.Add(sl);
            result.Add(snl);
            return result;
        }
        else
        {
            var p = purview.Split(',');
            List<int> allows = new List<int>();     //有权限访问的Document_ID列表
            //转 Document_ID 权限列表
            Dictionary<int, string> dict = CommonConst.PurviewDict();
            int i = 0;
            foreach (var s in p)
            {
                i = 0;
                if (dict.ContainsValue(s))
                {
                    i = dict.Where(m => m.Value == s).Select(m => m.Key).First();
                    allows.Add(i);
                    sl += i.ToString() + ",";
                }
            }

            //allows 以外的id都为没权限访问
            foreach (var l in list)
            {
                int flag = 0;
                foreach (int j in allows)
                {
                    if (l.OfficeAutomatifon_Document_ID == j)
                    {
                        flag++;
                        break;
                    }
                }
                if (flag == 0)
                {
                    snl += l.OfficeAutomatifon_Document_ID + ",";
                }
            }

            result.Add(sl);
            result.Add(snl);
            return result;
        }
    }

    public static List<DataEntity.DTO.AgentDto> ChangeAgentDtos(List<Agent> agents)
    {
        if (agents == null || agents.Count == 0)
            return null;
        List<DataEntity.DTO.AgentDto> results = new List<DataEntity.DTO.AgentDto>();
        foreach (var i in agents)
        {
            results.Add(new DataEntity.DTO.AgentDto
            {
                AgentEmpID = i.AgentEmpID,
                AgentEmpName = i.AgentEmpName
            });
        }
        return results;
    }

    /// <summary>
    /// 写入日志
    /// </summary>
    /// <param name="log"></param>
    public static void WriteLogin(string log,string path)
    {


        ECOA.Common.EventTxtLog eventLogin = new ECOA.Common.EventTxtLog(path);

        eventLogin.WriteLog(log);

    }
}

public class SendMes
{
    public string EmpName{get;set;}
    public string MessageTitle{get;set;}
    public string MessageBody{get;set;}
}
