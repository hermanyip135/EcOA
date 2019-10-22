using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;
using DataAccess.Operate;
using DataEntity;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

/// <summary>
/// OfficialSealControl 的摘要说明
/// </summary>
public class OfficialSealControl
{
	public OfficialSealControl()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    #region old 
    public static int CreateFlow(string s, string MainID)
    {
        if (s == "" || s == null)
            return 0;
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        //DataSet ds = new DataSet();
        //DataRow dr = ds.Tables[0].Rows[0];

        T_OfficeAutomation_Flow flows;

        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdx(MainID, 2);

        //20170314修改
        //string kw = "收费许可证|、资质证等证件申办/年审资料|、解除或变更房屋租赁合同申请表|、法定代表人证明书|、营执|、代码证|、法人代表身份证|、国地税证|、代办人身份证|、门前三包|、治安责任书|、承诺书|、经济普查表|、机构情况调查表|、产业活动单位情况表|、其他政府规定格式文本资料|、租赁合同复印件（报街道或税用）|、房屋的情况说明|、办理租赁登记所需其他街道证明文件|";
        string kw = "解除或变更房屋租赁合同申请表|、公司证件|、法人代表身份证|、租赁合同复印件（报街道或税用）|、房屋的情况说明|、办理租赁登记所需其他街道证明文件|";
        string[] ems;
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "0067")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 30;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 11;
                break;
            }
        }

        kw = "中国移动专线类集团信息化产品办理表|、中国电信网络快车(LAN)业务登记表|、广东盈通MPLS VPN业务登记表|、电信机房出入登记表|、广州电信互联网数据中心客户维护工作表|、广州数据中心(IDC)业务受理表|、中国电信手机业务各类证明书函|、光纤施工证明及撤铺证明函|、广州电信IDC客户证申请表|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3808")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 3;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 12;
                break;
            }
        }

        kw = "行政部涉及费用合同|、车辆险|、公司责任险|、分行物品财产保险变更|、退保申请|、投保申请|、索赔文件|、工程类文件|、电信宽带业务（ADSL）|、电信业务单|、话费查询申请|、代扣电话|、话费申请|、水电费取消/变更|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3397")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3397";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "沈凯飞";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 4;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                if (s.Contains("行政部涉及费用合同"))
                {
                    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                    try
                    {
                        if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                        {
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                            t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                            da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                        }
                    }
                    catch
                    {
                    }
                }
                //return 12;
                break;
            }
        }

        kw = "在职或收入证明|、营执（旅游）|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,33690")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602,33690";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴,张晓莹";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 131;  
                break;
            }
        }

        //kw = "营执（旅游）"; //20170314新增
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //return 132;
        //        break;
        //    }
        //}

        kw = "核查员工在职情况|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,33690")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602,33690,23799";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴,张晓莹,邱超琼";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "执业证复印件|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 13);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "43598")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "43598";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "刘淑怡";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }


        //kw = "在职证明"; //M_已删 20151010
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //return 132;
        //        break;
        //    }
        //}

        kw = "发票证明|、发票遗失|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]) && !s.Contains("开具租金"))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 18);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 18;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 141;
                break;
            }
        }

        kw = "公司账户证明|、致银行及税局的相关文件|、开户/销户委托书|、开户许可证|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 142;
                break;
            }
        }

        //2016-8-3 移除 网络IT合同|、清洁合同|、饮用水合同|、工程安装合同|、制作合同|、发布合同|、空调采购合同|、消防合同|、防盗系统合同|、电信合同|、装修合同等合同类|、
        kw = "一手项目合同/协议|、项目投标及封条|、催款函|、二手交易佣金确认书|、中介付款通知书|、二手交易的买卖/租赁合同|、中介服务合同|、客户确认书|、客户确认及参观登记表|、其他合同（活动类等）|、项目代理合同/补充协议|、项目合作协议（电商/发展商）|、项目中介服务合同|、项目续约协议";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 15;
                break;
            }
        }

        kw = "租赁合同|、开具租金发票证明|、补充协议|、退租协议|、分行租铺调整协议|、减租协议|、变更业主的三方协议|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]) && !s.Contains("项目代理合同") && !s.Contains("二手交易的买卖") && !s.Contains("报街道或税用"))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "0067")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "0067";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘海燕";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 30;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }

                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        //20170531注释掉，改为如果选择物业部自主招聘类则根据部门插入不同的审批人（肖虹提的需求）
        //kw = "物业部自主招聘类|";
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 13);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "20861")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "51675";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "肖虹";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //2016-8-3  去掉法律部审核改成郑纯宁
        //        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
        //        //try
        //        //{
        //        //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792")
        //        //    {
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792";
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心";
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
        //        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //        //    }
        //        //}
        //        //catch
        //        //{
        //        //}
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 17;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        break;
        //    }
        //}

        kw = "其他招聘类（含项目部）|";
        ems = kw.Split('、');
        //20170527 修改为翁文格审批，以前是王子君
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "21779")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "51677";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "翁文格";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //2016-8-3 去掉法律部
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                break;
            }
        }

        kw = "特殊津贴报销文件|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "33690")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "33690";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "张晓莹";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 14;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "（拆街）合作协议（物业部）|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,61275,43781,20208,41960";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "61275,43781,20208,41960";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "冯琰,钟惠贤,陈婉娜,官东升";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "5585";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "宁伟雄";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 19;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 231;
                break;
            }
        }

        kw = "物业部佣金结算/成交明细表|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,61275,43781,20208,41960";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "61275,43781,20208,41960";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "冯琰,钟惠贤,陈婉娜,官东升";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 232;
                break;
            }
        }

        kw = "授权人员领取物业部自接“项目佣金授权书”|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 11);
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,61275,43781,20208,41960";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 11);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "61275,43781,20208,41960";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "冯琰,钟惠贤,陈婉娜,官东升";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }

                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,23799")
                    {
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 15);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                ////flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                //    {
                //        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 16);
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 233;
                break;
            }
        }

        kw = "项目部收佣明细及一手项目委托收款证明|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3575")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3575";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "招健辉";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 25;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 234;
                break;
            }
        }

        kw = "支付证明（涉及拆街）|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,61275,43781,20208,41960";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升 ";
                    //    t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                    //    da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "61275,43781,20208,41960";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "冯琰,钟惠贤,陈婉娜,官东升 ";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 11;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 12);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "5585";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "宁伟雄";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,24517,20208,41960,43781")
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 11);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "16945,61275,43781,24517,20208,41960,43781";
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "胡雅丝,冯琰,钟惠贤,李红梅,陈婉娜,官东升,钟惠贤";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "5585";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "宁伟雄";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 19;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                break;
            }
        }

        kw = "支付证明（不涉及拆街）|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "退水电按金付款方证明|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13545";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "黄志超";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 20;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 235;
                break;
            }
        }

        kw = "授权人员领取佣金支票证明|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602")
                    {
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 25);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //20170314 去掉法律部审核
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                //return 3;
                break;
            }
        }

        kw = "拆街合作协议（项目部）|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 12);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "24962")
                    {
                        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 11);
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "24962";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "吴惠卿";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 12;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "5585";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "宁伟雄";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 19;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //return 235;
                break;
            }
        }

        kw = "微信认证|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3189")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1401";
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "潘慧敏";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3189";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何旭晖";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 26;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 29);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3808")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4229";
                        //t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李粤湘";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3808";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "何智峰";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 29;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "区域广告位合同、广日报纸广告合同|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 27);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13110")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "13110";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "刘秀霞";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 27;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4229";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李粤湘";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 28;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //2016-8-3 取消法律部审核
                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "网络端口合同|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 27);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "2696")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "2696";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李凤娟";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 27;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4229";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李粤湘";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 28;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                //2016-8-3 取消法律部审核
                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }
        kw = "自媒体文件|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                
                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }
        //20170811李小清
        kw = "涉及费用招聘合同/协议（含物业部及项目部)|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "21779,51677")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "21779,51677";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "王子君,翁文格";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 13;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                 
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }
        kw = "参加中介协会会议等提交资料|";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "4229";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李粤湘";
                        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 28;
                        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                    }
                }
                catch
                {
                }
                break;
            }
        }

        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
        if (flows != null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 30); //外联部法律部后面
        return 0;
    }
    #endregion

    #region new
    public static int NewCreateFlow(string s, string MainID)
    {

        if (s == "" || s == null)
            return 0;

        string[] selectlist = s.Split( '|');

        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
      

        //DataSet ds = new DataSet();
        //DataRow dr = ds.Tables[0].Rows[0];

        T_OfficeAutomation_Flow flows;

        da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndAfterIdx(MainID, 2);

        //20170314修改
        //string kw = "收费许可证|、资质证等证件申办/年审资料|、解除或变更房屋租赁合同申请表|、法定代表人证明书|、营执|、代码证|、法人代表身份证|、国地税证|、代办人身份证|、门前三包|、治安责任书|、承诺书|、经济普查表|、机构情况调查表|、产业活动单位情况表|、其他政府规定格式文本资料|、租赁合同复印件（报街道或税用）|、房屋的情况说明|、办理租赁登记所需其他街道证明文件|";
        string kw = "解除或变更房屋租赁合同申请表、公司证件、法人代表身份证、租赁合同复印件（报街道或税用）、房屋的情况说明、办理租赁登记所需其他街道证明文件";
        string[] ems;
        
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p=>p==ems[i]).FirstOrDefault()!=null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "0067")
                    {

                         AddFlow(MainID, 30, "潘海燕", "0067");     
                    }
                }
                catch
                {
                }
                //return 11;
                break;
            }
        }

        kw = "中国移动专线类集团信息化产品办理表、中国电信网络快车(LAN)业务登记表、广东盈通MPLS VPN业务登记表、电信机房出入登记表、广州电信互联网数据中心客户维护工作表、广州数据中心(IDC)业务受理表、中国电信手机业务各类证明书函、光纤施工证明及撤铺证明函、广州电信IDC客户证申请表";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 3);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3808")
                    {
                        AddFlow(MainID, 3, "何智峰", "3808");     
                    }
                }
                catch
                {
                }
                //return 12;
                break;
            }
        }

        kw = "行政部涉及费用合同、车辆险、公司责任险、分行物品财产保险变更、退保申请、投保申请、索赔文件、工程类文件、电信宽带业务（ADSL）、电信业务单、话费查询申请、代扣电话、话费申请、水电费取消/变更";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 4);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3397")
                    {

                        AddFlow(MainID, 4, "沈凯飞", "3397"); 
                    }
                }
                catch
                {
                }
                if (s.Contains("行政部涉及费用合同"))
                {
                    flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                    try
                    {
                        if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                        {
                            AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536"); 
                        }
                    }
                    catch
                    {
                    }
                }
                //return 12;
                break;
            }
        }

        kw = "在职或收入证明、营执（旅游）";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,33690")
                    {
                        AddFlow(MainID, 15, "朱晓晴,张晓莹", "30602,33690"); 
                    }
                }
                catch
                {
                }
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        AddFlow(MainID, 16, "郑纯宁", "15300");   
                    }
                }
                catch
                {
                }
                //return 131;  
                break;
            }
        }

        //kw = "营执（旅游）"; //20170314新增
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //return 132;
        //        break;
        //    }
        //}

        kw = "核查员工在职情况";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,33690")
                    {
                        AddFlow(MainID, 15, "朱晓晴,张晓莹,邱超琼", "30602,33690,23799");   
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "执业证复印件";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 13);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "43598")
                    {
                        AddFlow(MainID, 13, "刘淑怡", "43598");   
                    }
                }
                catch
                {
                }
                break;
            }
        }


        //kw = "在职证明"; //M_已删 20151010
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "30602";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "朱晓晴";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 15;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //return 132;
        //        break;
        //    }
        //}

        kw = "发票证明、发票遗失";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null && !s.Contains("开具租金"))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 18);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        AddFlow(MainID, 18, "黄志超", "13545");   
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        AddFlow(MainID, 20, "黄志超", "13545");                 
                    }
                }
                catch
                {
                }
                //return 141;
                break;
            }
        }

        kw = "公司账户证明、致银行及税局的相关文件、开户/销户委托书、开户许可证";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        AddFlow(MainID, 20, "黄志超", "13545");       
                    }
                }
                catch
                {
                }
                //return 142;
                break;
            }
        }

        //2016-8-3 移除 网络IT合同|、清洁合同|、饮用水合同|、工程安装合同|、制作合同|、发布合同|、空调采购合同|、消防合同|、防盗系统合同|、电信合同|、装修合同等合同类|、
        kw = "一手项目合同/协议、项目投标及封条、催款函、二手交易佣金确认书、中介付款通知书、二手交易的买卖/租赁合同、中介服务合同、客户确认书、客户确认及参观登记表、其他合同（活动类等）、项目代理合同/补充协议、项目合作协议（电商/发展商）、项目中介服务合同、项目续约协议";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");    
                    }
                }
                catch
                {
                }
                //return 15;
                break;
            }
        }

        kw = "租赁合同、开具租金发票证明、补充协议、退租协议、分行租铺调整协议、减租协议、变更业主的三方协议";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null && !s.Contains("项目代理合同") && !s.Contains("二手交易的买卖") && !s.Contains("报街道或税用"))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 30);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "0067")
                    {
                        AddFlow(MainID, 30, "潘海燕", "0067");    
                    }
                }
                catch
                {
                }

                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");    
                    }
                }
                catch
                {
                }
                break;
            }
        }

        //20170531注释掉，改为如果选择物业部自主招聘类则根据部门插入不同的审批人（肖虹提的需求）
        //kw = "物业部自主招聘类|";
        //ems = kw.Split('、');
        //for (int i = 0; i < ems.Length; i++)
        //{
        //    if (s.Contains(ems[i]))
        //    {
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 13);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "20861")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "51675";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "肖虹";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        //2016-8-3  去掉法律部审核改成郑纯宁
        //        //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
        //        //try
        //        //{
        //        //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792")
        //        //    {
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792";
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心";
        //        //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
        //        //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //        //    }
        //        //}
        //        //catch
        //        //{
        //        //}
        //        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
        //        try
        //        {
        //            if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
        //            {
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
        //                t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 17;
        //                da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //        break;
        //    }
        //}

        kw = "其他招聘类（含项目部）";
        ems = kw.Split('、');
        //20170527 修改为翁文格审批，以前是王子君
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "21779")
                    {
                        AddFlow(MainID, 13, "翁文格", "51677");    
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        AddFlow(MainID, 16, "郑纯宁", "15300");    
                    }
                }
                catch
                {
                }
                //2016-8-3 去掉法律部
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                break;
            }
        }

        kw = "特殊津贴报销文件";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 14);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "33690")
                    {
                        AddFlow(MainID, 14, "张晓莹", "33690");      
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        AddFlow(MainID, 16, "郑纯宁", "15300");    
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "（拆街）合作协议（物业部）";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    AddFlow(MainID, 11, "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升", "16945,61275,43781,20208,41960");    
                    //}
                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        AddFlow(MainID, 11, "冯琰,钟惠贤,陈婉娜,官东升", "61275,43781,20208,41960");
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        AddFlow(MainID, 19, "宁伟雄", "5585");    
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");    
                    }
                }
                catch
                {
                }
                //return 231;
                break;
            }
        }

        kw = "物业部佣金结算/成交明细表";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    AddFlow(MainID, 11, "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升", "16945,61275,43781,20208,41960");    
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        AddFlow(MainID, 11, "冯琰,钟惠贤,陈婉娜,官东升", "61275,43781,20208,41960");
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");    
                    }
                }
                catch
                {
                }
                //return 232;
                break;
            }
        }

        kw = "授权人员领取物业部自接“项目佣金授权书”";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{

                    //    AddFlow(MainID, 11, "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升", "16945,61275,43781,20208,41960");     
                    //}

                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {

                        AddFlow(MainID, 11, "冯琰,钟惠贤,陈婉娜,官东升", "61275,43781,20208,41960");
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602,23799")
                    {
                        AddFlow(MainID, 15, "朱晓晴", "30602");     
                    }
                }
                catch
                {
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                ////flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                //    {
                //        //da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 16);
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "15300";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "郑纯宁";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 16;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");       
                    }
                }
                catch
                {
                }
                //return 233;
                break;
            }
        }

        kw = "项目部收佣明细及一手项目委托收款证明";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3575")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "3575";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "招健辉";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 25;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");       
                    }
                }
                catch
                {
                }
                //return 234;
                break;
            }
        }

        kw = "支付证明（涉及拆街）";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 11);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,20208,41960")
                    //{
                    //    AddFlow(MainID, 11, "胡雅丝,冯琰,钟惠贤,陈婉娜,官东升", "16945,61275,43781,20208,41960");      
                    //}
                    //2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "61275,43781,20208,41960")
                    {
                        AddFlow(MainID, 11, "冯琰,钟惠贤,陈婉娜,官东升", "61275,43781,20208,41960");
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 12);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        AddFlow(MainID, 12, "宁伟雄", "5585");      
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    //if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "16945,61275,43781,24517,20208,41960,43781")
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");       
                    }
                }
                catch
                {
                }
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "5585";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "宁伟雄";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 19;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                break;
            }
        }

        kw = "支付证明（不涉及拆街）";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        AddFlow(MainID, 20, "黄志超", "13545"); 
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "退水电按金付款方证明";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 20);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13545")
                    {
                        AddFlow(MainID, 20, "黄志超", "13545"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536"); 
                    }
                }
                catch
                {
                }
                //return 235;
                break;
            }
        }

        kw = "授权人员领取佣金支票证明";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 15);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 25);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "30602")
                    {
                        AddFlow(MainID, 15, "朱晓晴", "30602"); 
                    }
                }
                catch
                {
                }
                //20170314 去掉法律部审核
                //flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                //try
                //{
                //    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                //    {
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = "1865,6189,13398,13776,30792,8536";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳";
                //        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = 100;
                //        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
                //    }
                //}
                //catch
                //{
                //}
                //return 3;
                break;
            }
        }

        kw = "拆街合作协议（项目部）";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 12);
                //flows2 = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 24);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "24962")
                    {
                        AddFlow(MainID, 12, "吴惠卿", "24962"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 19);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "5585")
                    {
                        AddFlow(MainID, 19, "宁伟雄", "5585"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536"); 
                    }
                }
                catch
                {
                }
                //return 235;
                break;
            }
        }

        kw = "微信认证";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 26);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3189")
                    {
                        AddFlow(MainID, 26, "何旭晖", "3189"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 29);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "3808")
                    {
                        AddFlow(MainID, 29, "何智峰", "3808"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536"); 
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "区域广告位合同、广日报纸广告合同";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 27);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "13110")
                    {
                        AddFlow(MainID, 27, "刘秀霞", "13110");  
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        AddFlow(MainID, 28, "李粤湘", "4229");  
                       
                    }
                }
                catch
                {
                }
                //2016-8-3 取消法律部审核
                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");  
                    }
                }
                catch
                {
                }
                break;
            }
        }

        kw = "网络端口合同";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 27);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "2696")
                    {
                        AddFlow(MainID, 27, "李凤娟", "2696");  
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        AddFlow(MainID, 28, "李粤湘", "4229");  
                    }
                }
                catch
                {
                }
                //2016-8-3 取消法律部审核
                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");  
                    }
                }
                catch
                {
                }
                break;
            }
        }
        kw = "自媒体文件";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {

                //2017-08-10添加法律部审核
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536");  
                     
                    }
                }
                catch
                {
                }
                break;
            }
        }
        //20170811李小清
        kw = "涉及费用招聘合同/协议（含物业部及项目部)";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (selectlist.Where(p => p == ems[i]).FirstOrDefault() != null)
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 16);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "21779,51677")
                    {
                        AddFlow(MainID, 13, "王子君,翁文格", "21779,51677");  
                    }

                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 17);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "15300")
                    {
                        AddFlow(MainID, 16, "郑纯宁", "15300"); 
                    }
                }
                catch
                {
                }
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 100);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "1865,6189,13398,13776,30792,8536")
                    {
                        AddFlow(MainID, 100, "李蓬桂,陈宇平,何恺鹏,苏秉星,潘焕心,甘桂芳", "1865,6189,13398,13776,30792,8536"); 
                    }
                }
                catch
                {
                }
                break;
            }
        }
        kw = "参加中介协会会议等提交资料";
        ems = kw.Split('、');
        for (int i = 0; i < ems.Length; i++)
        {
            if (s.Contains(ems[i]))
            {
                flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 28);
                try
                {
                    if (flows == null || flows.OfficeAutomation_Flow_EmployeeID != "4229")
                    {
                        AddFlow(MainID, 28, "李粤湘", "4229"); 
                    }
                }
                catch
                {
                }
                break;
            }
        }

     

        flows = da_OfficeAutomation_Flow_Inherit.SelectByMainIDAndIdx(MainID, 105);
        if (flows != null)
            da_OfficeAutomation_Flow_Inherit.DeleteByMainIDAndIdx(MainID, 30); //外联部法律部后面
        return 0;
    }


    public static bool AddFlow(string MainID, int idx, string employee, string employeeID)
    {
        DA_OfficeAutomation_Flow_Inherit da_OfficeAutomation_Flow_Inherit = new DA_OfficeAutomation_Flow_Inherit();
        T_OfficeAutomation_Flow t_OfficeAutomation_Flow = new T_OfficeAutomation_Flow();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_MainID = new Guid(MainID);
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Suggestion = "";
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_ID = Guid.NewGuid();
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_EmployeeID = employeeID;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Employee = employee;
        t_OfficeAutomation_Flow.OfficeAutomation_Flow_Idx = idx;
        da_OfficeAutomation_Flow_Inherit.Insert(t_OfficeAutomation_Flow);
        return true;
    }
    #endregion
}