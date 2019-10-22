using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///CommonConst 的摘要说明
/// </summary>
public class CommonConst
{
    #region 流程特殊人员

    #region 行政部

    /// <summary>
    /// 报废申请表中行政部负责审理的同事工号：18831
    /// </summary>
    public static string EMP_ADMINISTRATION_OPERATOR_ID = "18331";
    /// <summary>
    /// 报废申请表中行政部负责审理的同事姓名：陈秀球
    /// </summary>
    public static string EMP_ADMINISTRATION_OPERATOR_NAME = "陈秀球";

    /// <summary>
    /// 资产、报废申请表中的旧表时间
    /// </summary>
    public static string ASSET_OLD_TIME = "2015-07-16";

    /// <summary>
    /// 减佣、让佣申请表中的旧表时间
    /// </summary>
    public static string REDUCECOMM_OLD_TIME = "2015-06-11";

    /// <summary>
    /// 20150901Emma修改需求的旧表时间
    /// </summary>
    public static string EMMA_OLD_TIME = "2015-09-01";

    /// <summary>
    /// 广告宣传需求请表中的旧表时间
    /// </summary>
    public static string PROPAGANDA_OLD_TIME = "2017-04-10";

    /// <summary>
    /// 20170508分行续约申请表中的旧表时间
    /// </summary>
    public static string BRANCHCONTRACT_OLD_TIME = "2017-05-09";

    /// <summary>
    /// 20170526员工购租楼宇申报及免佣福利申请表中的旧表时间
    /// </summary>
    public static string BUYBUILDING_OLD_TIME = "2017-06-02";

    /// <summary>
    /// 计算机及相关设备购买申请表中行政部负责审理的同事工号：14470
    /// </summary>
    public static string EMP_ADMINISTRATION_OPERATOR2_ID = "14470";
    /// <summary>
    /// 计算机及相关设备购买申请表中行政部负责审理的同事姓名：黄凤珊
    /// </summary>
    public static string EMP_ADMINISTRATION_OPERATOR2_NAME = "黄凤珊";

    #endregion

    #region 财务部

    /// <summary>
    /// 报废申请表中财务部负责计算净值的同事工号：45664
    /// </summary>
    public static string EMP_FINANCE_OPERATOR_ID = "45664";
    /// <summary>
    /// 报废申请表中财务部负责计算净值的同事姓名：源浩灵
    /// </summary>
    public static string EMP_FINANCE_OPERATOR_NAME = "源浩灵";

    /// <summary>
    /// 报废申请表中财务部负责成交备案的同事工号：24517
    /// </summary>
    public static string EMP_FINANCE_OPERATOR2_ID = "24517";
    /// <summary>
    /// 报废申请表中财务部负责成交备案的同事姓名：李红梅
    /// </summary>
    public static string EMP_FINANCE_OPERATOR2_NAME = "李红梅";

    ///// <summary>
    ///// 购租房免佣申请表中财务部负责的同事工号：16945
    ///// </summary>
    //public static string EMP_FINANCE_OPERATOR3_ID = "16945";
    ///// <summary>
    ///// 购租房免佣申请表中财务部负责的同事姓名：胡雅丝
    ///// </summary>
    //public static string EMP_FINANCE_OPERATOR3_NAME = "胡雅丝";

    #region [2019-10-21 财务部将 胡雅丝（16945） 权限移交比 钟惠贤（43781）]
    /// <summary>
    /// 购租房免佣申请表中财务部负责的同事工号：43781
    /// </summary>
    public static string EMP_FINANCE_OPERATOR3_ID = "43781";
    /// <summary>
    /// 购租房免佣申请表中财务部负责的同事姓名：胡雅丝
    /// </summary>
    public static string EMP_FINANCE_OPERATOR3_NAME = "钟惠贤"; 
    #endregion

    /// <summary>
    /// 财务部公共帐号：acc08
    /// </summary>
    public static string EMP_FINANCE_PUBLIC_ID = "acc08";

    #endregion

    #region 后勤事务部

    /// <summary>
    /// 后勤事务部经办人工号：23514
    /// </summary>
    public static string EMP_LOGISTICS_OPERATOR_ID = "23514";
    /// <summary>
    /// 后勤事务部经办人姓名：张绍欣
    /// </summary>
    public static string EMP_LOGISTICS_OPERATOR_NAME = "张绍欣";

    /// <summary>
    /// 后勤事务部负责人工号：10054
    /// </summary>
    public static string EMP_LOGISTICS_MANAGER_ID = "10054";
    /// <summary>
    /// 后勤事务部负责人姓名：黄瑛
    /// </summary>
    public static string EMP_LOGISTICS_MANAGER_NAME = "黄瑛";

    #endregion

    #region 人力资源部

    /// <summary>
    /// 计算机及其他设备购买申请表中人力资源部经办人工号：21392
    /// </summary>
    public static string EMP_HR_OPERATOR_ID = "21392";
    /// <summary>
    /// 计算机及其他设备购买申请表中人力资源部经办人姓名：黎泫滢
    /// </summary>
    public static string EMP_HR_OPERATOR_NAME = "黎泫滢";

    /// <summary>
    /// 购租房免佣申请表中人力资源部经办人工号：23799
    /// </summary>
    public static string EMP_HR_OPERATOR1_ID = "23799";
    /// <summary>
    /// 购租房免佣申请表中人力资源部经办人姓名：邱超琼
    /// </summary>
    public static string EMP_HR_OPERATOR1_NAME = "邱超琼";

    /// <summary>
    /// HR经理工号：15300
    /// </summary>
    public static string EMP_HR_MANAGER_ID = "15300";
    /// <summary>
    /// HR经理姓名：郑纯宁
    /// </summary>
    public static string EMP_HR_MANAGER_NAME = "郑纯宁";

    #endregion

    #region  法律部

    /// <summary>
    ///法律部负责天河区员工工号：1865
    /// </summary>
    public static string EMP_LAW_TIANHE_ID = "1865";
    /// <summary>
    /// 法律部负责天河区员工姓名：李蓬桂
    /// </summary>
    public static string EMP_LAW_TIANHE_NAME = "李蓬桂";

    /// <summary>
    ///法律部负责海珠区员工工号：6189
    /// </summary>
    public static string EMP_LAW_HAIZHU_ID = "6189";
    /// <summary>
    /// 法律部负责海珠区员工姓名：陈宇平
    /// </summary>
    public static string EMP_LAW_HAIZHU_NAME = "陈宇平";

    /// <summary>
    ///法律部负责工商铺员工工号：13776
    /// </summary>
    public static string EMP_LAW_GONGSHANGPU_ID = "13776";
    /// <summary>
    /// 法律部负责工商铺员工姓名：苏秉星
    /// </summary>
    public static string EMP_LAW_GONGSHANGPU_NAME = "苏秉星";

    /// <summary>
    ///法律部负责其他区员工工号：13398
    /// </summary>
    public static string EMP_LAW_QITA_ID = "13398";
    /// <summary>
    /// 法律部负责其他区员工姓名：何恺鹏
    /// </summary>
    public static string EMP_LAW_QITA_NAME = "何恺鹏";

    /// <summary>
    /// 法律部文员姓名：李小清
    /// </summary>
    public static string EMP_LAW_OPERATOR_NAME = "李小清";

    /// <summary>
    /// 法律部文员工号：17642
    /// </summary>
    public static string EMP_LAW_OPERATOR_ID = "17642";

    #endregion

    #region 资讯科技部

    /// <summary>
    ///IT部经办人工号：5951
    /// </summary>
    public static string EMP_IT_OPERATOR_ID = "5951";
    /// <summary>
    /// IT部经办人姓名：倪秀珊
    /// </summary>
    public static string EMP_IT_OPERATOR_NAME = "倪秀珊";

    /// <summary>
    ///IT部负责MCOA同事工号：9154
    /// </summary>
    public static string EMP_IT_MCOA_ID = "9154";
    /// <summary>
    /// IT部负责MCOA同事姓名：梅竞新
    /// </summary>
    public static string EMP_IT_MCOA_NAME = "梅竞新";

    /// <summary>
    ///IT部软件组主管工号：3189
    /// </summary>
    public static string EMP_IT_SOFTWARE_MANAGER_ID = "3189";
    /// <summary>
    /// IT部软件组主管姓名：何旭晖
    /// </summary>
    public static string EMP_IT_SOFTWARE_MANAGER_NAME = "何旭晖";

    /// <summary>
    ///IT部硬件维护组主管工号：1236
    /// </summary>
    public static string EMP_IT_HARDWARE_MANAGER_ID = "1236";
    /// <summary>
    /// IT部硬件维护组主管姓名：梁锐华
    /// </summary>
    public static string EMP_IT_HARDWARE_MANAGER_NAME = "梁锐华";

    /// <summary>
    ///IT部系统数据组主管工号：5128
    /// </summary>
    public static string EMP_IT_DATA_MANAGER_ID = "5128";
    /// <summary>
    /// IT部系统数据组主管姓名：霍志成
    /// </summary>
    public static string EMP_IT_DATA_MANAGER_NAME = "霍志成";

    /// <summary>
    ///IT部经理工号：3808
    /// </summary>
    public static string EMP_IT_MANAGER_ID = "3808";
    /// <summary>
    /// IT部经理姓名：何智峰
    /// </summary>
    public static string EMP_IT_MANAGER_NAME = "何智峰";

    /// <summary>
    ///营运支持经理工号：1909
    /// </summary>
   // public static string EMP_OPERATINGSUPPORT_MANAGER_ID = "1909";
    /// <summary>
    /// 营运支持经理姓名：潘宇馥
    /// </summary>
   // public static string EMP_OPERATINGSUPPORT_MANAGER_NAME = "潘宇馥";
    /// <summary>
    ///58088
    /// </summary>
    public static string EMP_OPERATINGSUPPORT_MANAGER_ID = "58088";
    /// <summary>
    /// 总办 陈晓青
    /// </summary>
    public static string EMP_OPERATINGSUPPORT_MANAGER_NAME = "陈晓青A";

    #endregion

    #region 项目部

    /// <summary>
    /// 项目部负责合同条款申请表和项目费用申请表的同事姓名：梁绮云
    /// </summary>
    public static string EMP_PROJECT_CLAUSEANDPROJCOST_NAME = "梁绮云";

    /// <summary>
    /// 项目部所有申请完成后抄送的同事姓名：关婉莹,李艳秋
    /// </summary>
    public static string EMP_PROJECT_COPYTO_NAME = "关婉莹,李艳秋";

    #endregion

    #region 其他：汇瀚，总经理，直属总经理人员等

    /// <summary>
    ///汇瀚负责人工号：13161
    /// </summary>
  //  public static string EMP_MORTGAGE_MANAGER_ID = "13161";
    /// <summary>
    /// 汇瀚负责人工号：0111
    /// </summary>
    public static string EMP_MORTGAGE_MANAGER_ID = "0111";
    ///// <summary>
    ///// 汇瀚负责人姓名：曹颖思
    ///// </summary>
    //public static string EMP_MORTGAGE_MANAGER_NAME = "曹颖思";
    /// <summary>
    /// 汇瀚负责人姓名：黄蕙晶 
    /// </summary>
    public static string EMP_MORTGAGE_MANAGER_NAME = "黄蕙晶 ";
    /// <summary>
    ///董事总经理工号：0001
    /// </summary>
    public static string EMP_GENERALMANAGER_ID = "0001";
    /// <summary>
    /// 董事总经理姓名：黄轩明
    /// </summary>
    public static string EMP_GENERALMANAGER_NAME = "黄轩明";

    /// <summary>
    /// 直属上司为黄生的人员：
    /// 黄筑筠（22563）、谢芃（3030）、李蕴茹（27206）、黄瑛（10054）、黄洁珍（0025）、陈洁丽（2377）、李毅华（5042）、
    /// 陈宋林（2649）、陈秋炳（4485）、朱伟洲（0002）、潘婉霞（0091）、张焯贤（25622）、叶国安（0043）、 杜燕玲（0385）、
    /// 罗思源（0006）、易伟锋（2722）、钟惠泉（22181）、关婉莹（1649）、梁慧文（0077）、曹颖思（13161）
    /// </summary>
    public static string EMP_IMMEDIATEBOSS_ID = "22563|3030|33720|27206|10054|0025|2377|5042|2649|4485|0002|0091|25622|0043|0385|0006|2722|22181|1649|0077|13161";

    /// <summary>
    /// 直属上司为黄生的人员：
    /// 黄筑筠（22563）、谢芃（3030）、李蕴茹（27206）、黄瑛（10054）、黄洁珍（0025）、陈洁丽（2377）、李毅华（5042）、
    /// 陈宋林（2649）、陈秋炳（4485）、朱伟洲（0002）、潘婉霞（0091）、张焯贤（25622）、叶国安（0043）、 杜燕玲（0385）、
    /// 罗思源（0006）、易伟锋（2722）、钟惠泉（22181）、关婉莹（1649）、梁慧文（0077）、曹颖思（13161）|顾慧|彭明慧|梁健菁
    /// </summary>
    public static string EMP_IMMEDIATEBOSS_NAME = "黄筑筠|谢芃|罗蔼蕴|李蕴茹|黄瑛|黄洁珍|陈洁丽|李毅华|陈宋林|陈秋炳|朱伟洲|潘婉霞|张焯贤|叶国安|杜燕玲|罗思源|易伟锋|钟惠泉|关婉莹|梁慧文|曹颖思|顾慧|彭明慧|梁健菁";

    /// <summary>
    /// 总办2张表(减佣让佣，物业部承接一手项目报备)完成后需抄送给的人：黄筑筠,谢芃,罗蔼蕴,李红梅,张绍欣,黄瑛,张绍欣
    /// </summary>
    public static string EMP_GMO_COPYTO_NAME = "黄筑筠,谢芃,罗蔼蕴,李红梅,张绍欣,黄瑛,顾慧,彭明慧,张绍欣,梁健菁";

    /// <summary>
    /// 总办合作费(以及项目费用 20140528李红梅提出)完成后需抄送给的人：黄筑筠,谢芃,罗蔼蕴,陈志辉B,张绍欣,黄瑛,张绍欣
    /// </summary>
    public static string EMP_COOPCOST_COPYTO_NAME = "黄筑筠,谢芃,罗蔼蕴,陈志辉B,张绍欣,黄瑛,顾慧,彭明慧,张绍欣,梁健菁";

    /// <summary>
    /// 总办5位同事：黄筑筠,谢芃,顾慧,彭明慧,张绍欣,梁健菁
    /// </summary>
    public static string EMP_GMO_NAME = "黄筑筠,谢芃,顾慧,彭明慧,张绍欣,梁健菁";

    #endregion 

    #endregion

    #region 通知

    /// <summary>
    /// 已成功发送通知。
    /// </summary>
    public static string MSG_SEND_SUCCESS = "已成功发送通知。";

    /// <summary>
    /// 发送通知失败！
    /// </summary>
    public static string MSG_SEND_FAIL = "发送通知失败！";

    /// <summary>
    /// 无签名时提示：由于目前系统没有您的签名文件，\\n导致无法完成签名审批，\\n请电传签名文件至资讯科技部赵萍！
    /// </summary>
    public static string MSG_NO_SIGNIMAGE = "由于目前系统没有您的签名文件，\\n导致无法完成签名审批，\\n请电传签名文件至资讯科技部赵萍！";

    /// <summary>
    /// URL失效报错时提示：该页面未找到，或已经被删除！
    /// </summary>
    public static string MSG_URL_DISABLE = "该页面未找到，或已经被删除！";

    /// <summary>
    /// 流程编辑窗口将要关闭时提示：请确保流程中三个环节至少有一个环节启用，\\n否则该申请将很可能失败！
    /// </summary>
    public static string MSG_FLOW_ISCLOSING = "请确保流程中三个环节至少有一个环节启用，\\n否则该申请将无效！";

    /// <summary>
    /// 流程保存成功时提示：流程编辑成功！
    /// </summary>
    public static string MSG_FLOW_SUCCESSSAVE = "流程编辑成功！";

    /// <summary>
    /// 流程保存失败时提示：保存失败，部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！
    /// </summary>
    public static string MSG_FLOW_SAVEFAIL = "保存失败，部分人名不存在或不具备审批资格，\\n请修改，如依然失败，请联系资讯科技部！";

    /// <summary>
    /// 未开通编辑修改权限时提示：未开通编辑修改权限。
    /// </summary>
    public static string MSG_EDITPOWER_NOOPEN = "未开通编辑修改权限。";

    /// <summary>
    /// 申请表提交成功时提示：申请提交成功，等待相关人员审核！
    /// </summary>
    public static string MSG_APPLY_SUCCESSCOMMIT = "申请提交成功，等待相关人员审核！";

    #endregion

    #region 标记图案符号

    /// <summary>
    /// 行政部：√
    /// </summary>
    public static string SIGN_ADMINISTRATION = "√";

    /// <summary>
    /// 财务部：★
    /// </summary>
    public static string SIGN_FINANCE = "★";

    /// <summary>
    /// HR：■
    /// </summary>
    public static string SIGN_HR = "■";

    #endregion

    #region 行政部后五张表需发送或抄送的邮箱地址

    /// <summary>
    /// 行政部后五张表需发送或抄送的邮箱地址:梁锐华|倪秀珊|谢芃|黄筑筠|广州中原行政部|广州中原外联部|关玉肖|湛伟冰|杨智丽|徐琤华|黄嘉慧|源浩灵|郑纯宁|林亦玲|曹颖思|李蓬桂|陈妙桃|徐浩德
    /// </summary>
    public static string EMAILLIST_ADMIN = "liangrh@centaline.com.cn|nixs@centaline.com.cn|xiepeng@centaline.com.cn|huangzj.gz01@centaline.com.cn|gzzyxzball@centaline.com.cn|gzzywlball@centaline.com.cn|guanyx@centaline.com.cn|zhanwb@centaline.com.cn|yangzl.gz@centaline.com.cn|xuch@centaline.com.cn|huangjh.gz@centaline.com.cn|caojw.gz01@centaline.com.cn|zhengcn@centaline.com.cn|linyl@centaline.com.cn|caoys.gz@centaline.com.cn|lipg@centaline.com.cn|chenmt@centaline.com.cn|xuhd.gz@centaline.com.cn";

    #endregion

    public static string GetTempXmlPath(string mid)
    {
        return System.Web.HttpContext.Current.Server.MapPath("../../Temp/" + mid + ".xml");
    }

    /// <summary>
    /// 权限系统权限对应[OfficeAutomation_Document_ID]字典
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, string> PurviewDict()
    {
        //<int, string>：<OfficeAutomation_Document_ID,"权限字段">
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(1, "OA_Search_005");   //IT权限表(前线)
        dict.Add(3, "OA_Search_006");   //IT权限表(后勤)
        dict.Add(2, "OA_Search_007");   //软件系统开发需求申请表
        dict.Add(7, "OA_Search_008");   //计算机及相关设备需求申请表
        dict.Add(4, "OA_Search_009");   //报废申请表
        dict.Add(5, "OA_Search_010");   //资产调动
        dict.Add(6, "OA_Search_011");   //物业部成交商铺写字楼备案申请表
        dict.Add(8, "OA_Search_012");   //员工个人利益申请表
        dict.Add(9, "OA_Search_013");   //员工购租楼宇申报及免佣福利申请表
        dict.Add(10, "OA_Search_014");  //小汽车津贴申请表
        dict.Add(11, "OA_Search_015");  //退佣申请表
        dict.Add(12, "OA_Search_016");  //坏账申请表
        dict.Add(13, "OA_Search_017");  //减佣让佣申请表
        dict.Add(14, "OA_Search_018");  //项目费用申请表
        dict.Add(15, "OA_Search_019");  //合作费申请表
        //dict.Add(0, "OA_Search_020");  //物业部承接一手项目等报备申请表(字典表没有)
        dict.Add(17, "OA_Search_021");  //项目发展商额外奖金报备
        dict.Add(18, "OA_Search_022");  //恢复营业申请表F
        dict.Add(19, "OA_Search_023");  //撤铺/转铺申请表
        dict.Add(20, "OA_Search_024");  //暂停营业申请表
        dict.Add(21, "OA_Search_025");  //项目销售代理合同条款申请表
        dict.Add(22, "OA_Search_026");  //项目工衣申请表
        dict.Add(23, "OA_Search_027");  //项目宿舍及津贴费用申请表
        dict.Add(24, "OA_Search_028");  //项目报数申请表
        dict.Add(25, "OA_Search_029");  //项目联动报数申请表
        dict.Add(16, "OA_Search_031");  //物业部承接项目报备申请表
        dict.Add(26, "OA_Search_032");  //变更资料申请表
        dict.Add(29, "OA_Search_035");  //进修津贴申请表
        dict.Add(30, "OA_Search_036");  //特殊上数申请表
        dict.Add(31, "OA_Search_037");  //公章使用申请表
        dict.Add(28, "OA_Search_034");  //无线固话申请明细表
        dict.Add(32, "OA_Search_038");  //分行续约申请报告
        dict.Add(27, "OA_Search_033");  //应收佣金调整报告
        dict.Add(33, "OA_Search_039");  //营运部门自组织外出活动申请
        dict.Add(34, "OA_Search_040");  //入职欠交资料特殊申请
        dict.Add(35, "OA_Search_041");  //新分行总启费用申请表
        dict.Add(36, "OA_Search_042");  //新建分行可行性报告
        //dict.Add(0, "OA_Search_043");  //物业部一手项目追佣申请表(字典表没有)
        //dict.Add(0, "OA_Search_044");  //法律部追佣合作费处理申请(字典表没有)
        dict.Add(39, "OA_Search_045");  //通用申请表
        dict.Add(40, "OA_Search_046");  //合同条款申请表
        dict.Add(41, "OA_Search_047");  //超成数备案
        dict.Add(42, "OA_Search_048");  //关于享受本月佣金按全年一次性奖金发放申请表
        dict.Add(43, "OA_Search_049");  //市场推广费用申请
        dict.Add(44, "OA_Search_050");  //资产借调申请表
        dict.Add(45, "OA_Search_051");  //三级市场活动费用的申请
        //dict.Add(0, "OA_Search_052");  //项目部代理合同扣罚条款签名确认表(字典表没有)
        dict.Add(47, "OA_Search_053");  //网签变更、特殊申请表
        //dict.Add(49, "OA_Search_012");  //新员工个人利益申请表
        //dict.Add(0, "OA_Search_054");  //特殊个案申请表(字典表没有)
        dict.Add(80, "OA_Search_055");  //社保公积金特殊缴纳申请表
        dict.Add(52, "OA_Search_057");  //小汽车津贴申请表（项目部）
        dict.Add(53, "OA_Search_058");  //大额维修申请表
        dict.Add(54, "OA_Search_059");  //新增、维修项目报价（结算）明细表
        dict.Add(55, "OA_Search_060");  //广告宣传需求申请表
        dict.Add(56, "OA_Search_061");  //广告宣传预算使用异常申请表
        dict.Add(57, "OA_Search_062");  //发展商额外奖金新增申请及调整申请
        dict.Add(58, "OA_Search_063");  //借证担保申请
        dict.Add(59, "OA_Search_064");  //关于签署两方版本担保协议书的申请
        dict.Add(60, "OA_Search_065");  //三级市场一手项目欠必要性文件拉数申请
        dict.Add(61, "OA_Search_066");  //二级市场一手项目欠必要性文件拉数申请
        dict.Add(62, "OA_Search_067");  //物业部项目续约申请表
        dict.Add(63, "OA_Search_068");  //物业部承接新项目申请表
        dict.Add(64, "OA_Search_069");  //项目报数申请表(物业部加签)
        dict.Add(65, "OA_Search_070");  //错存帐户调整申请表
        //dict.Add(0, "OA_Search_071");  //物业部购买楼盘资料申请(没有字典)
        dict.Add(67, "OA_Search_072");  //项目部实收佣金调整申请表

        dict.Add(68, "OA_Search_073");  //临时借用资金申请表(没有字典)
        dict.Add(69, "OA_Search_074");  //特殊增编申请表
        dict.Add(70, "OA_Search_075");  //薪酬福利类证明开具申请表
        dict.Add(71, "OA_Search_076");  //项目部兼职申请
        //dict.Add(0, "OA_Search_077");  //申请内容修改申请表(没有字典)
        dict.Add(73, "OA_Search_078");  //物业部批量解hold申请
        //dict.Add(0, "OA_Search_079");  //超三天转介解除汇瀚HOLD佣申请
        dict.Add(75, "OA_Search_080");  //备案必须的内容
        dict.Add(76, "OA_Search_081");  //新建呼叫中心可行性报告
        dict.Add(77, "OA_Search_082");  //物业部自主招聘申请
        dict.Add(78, "OA_Search_083");  //招聘需求申请
        dict.Add(79, "OA_Search_084");  //项目部佣金分配指引
        dict.Add(82, "OA_Search_085");  //项目部通用申请
        dict.Add(83, "OA_Search_086");  //CPN拍摄需求申请
        dict.Add(84, "OA_Search_087");  //公积金缴存比例年度调整
        dict.Add(85, "OA_Search_088");  //放款申请
        dict.Add(88, "OA_Search_090");  //软件系统测试需求申请表
        dict.Add(89, "OA_Search_091");  //房友圈网签变更、特殊申请表
        dict.Add(90, "OA_Search_092"); //房友圈按揭不承办知会函
        dict.Add(91, "OA_Search_093"); //房友圈退案申请表
        dict.Add(92, "OA_Search_094"); //电子传真申请表
        dict.Add(93, "OA_Search_095"); //公积金缴存基数年度调整申请表
        dict.Add(94, "OA_Search_096"); //行政助理交接表
        dict.Add(95, "OA_Search_097"); //系统及密码交接表
        dict.Add(97, "OA_Search_098"); //公章使用申请表(项目部)
        dict.Add(99, "OA_Search_099"); //三级市场一手项目豁免自动坏申请
        dict.Add(100, "OA_Search_100"); //假期申请表
        return dict;
    }
}
