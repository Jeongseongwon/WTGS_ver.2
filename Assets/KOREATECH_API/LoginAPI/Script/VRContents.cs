using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ServiceType
{
    NONE = 0,
    로그인버전 = 1,
    런처연동버전 = 2
}
public enum ContentsType
{
    NONE = 0,

    //YEAR2020,
    쓰리디프린터HW설정 = 108239,
    전동기기동을위한동력설비공사 = 108233,
    감전방지및설비보호를위한접지설비공사 = 108219,
    화력발전소대용량송풍기정비초급 = 108235,
    자동차냉난방장치정비 = 111287,
    가솔린자동차배출가스정비 = 108399,
    가스텅스텐아크용접맞대기용접 = 108375,
    CNC선반조작 = 108351,
    CNC선반가공프로그래밍 = 108213,
    관류보일러설비설치 = 111301,

    //YEAR2021,
    범용밀링_엔드밀가공 = 138581,
    범용선반_편심나사작업 = 138583,
    CNC선반_홈테이퍼작업 = 138585,
    배전반설비공사 = 138587,
    배전기기설치공사 = 138589,
    지멘스PLC생산설비시스템 = 138591,
    사출금형및성형기운용 = 138593,
    터보냉동설비시공 = 138597,
    가스용접 = 138599,
    터보냉동설비운영 = 138601,
    공조냉동설비점검관리 = 138603,
    보일러설비운영_점검 = 138605,
    반도체유틸리티운영 = 138607,

    //YEAR2022,
    피복아크용접필렛용접 = 182933,
    피복아크용접파이프용접 = 182937,
    금속가공학기초 = 182941,
    변전설비점검 = 182945,
    변전설비안전 = 182945,
    건설기계정비크롤러형굴착기 = 182953,
    건설기계정비바퀴형굴착기 = 182957,
    태양광발전설치 = 182961,
    풍력발전감시 = 182965,
}

public struct VRCourse
{
    public string Name { get; set; }
    public string ContentsID { get; set; }
    public string CourseID { get; set; }

    public VRCourse(string courseID, string name, string contentsID)
    {
        Name = name;
        ContentsID = contentsID;
        CourseID = courseID;
    }
}

public static class VRContents
{
    static VRContents()
    {
    }

    public static List<VRCourse> m_VRContents = new List<VRCourse>();
    public static ContentsType m_ContentsType;

}


//KOO

public struct VRCourseKoo
{
    public string ncs_code_name { get; set; }
    public string course_id { get; set; }
    public string service_title { get; set; }
    public string study_days { get; set; }
    public string cancel_days { get; set; }
    public string review_days { get; set; }
    public string course_content_id { get; set; }
    public string course_short_description { get; set; }
    public string properties { get; set; }
    public string course_image_url { get; set; }
    public string course_syllabus_url { get; set; }
    public string vt_package_file_url { get; set; }
    public string mobile_compatibility_code { get; set; }
    public string course_video { get; set; }
    public string reformat_install_file_name { get; set; }
    public string reformat_install_file_url { get; set; }


    public VRCourseKoo(string ncs, string courseID, string serviceTitle, string sdays, string cdays, string rdays, string contentsID, string csd, string pro, string ciu, string csu, string vpfu, string mcc, string cv, string rifn, string rifu)
    {
        course_id = courseID;
        service_title = serviceTitle;
        course_content_id = contentsID;
        ncs_code_name = ncs;
        study_days = sdays;
        cancel_days = cdays;
        review_days = rdays;
        course_short_description = csd;
        properties = pro;
        course_image_url = ciu;
        course_syllabus_url = csu;
        vt_package_file_url = vpfu;
        mobile_compatibility_code = mcc;
        course_video = cv;
        reformat_install_file_name = rifn;
        reformat_install_file_url = rifu;

    }
}


public static class VRContentsKoo
{
    static VRContentsKoo()
    {
        // Add Contents        
    }

    public static List<VRCourseKoo> m_VRContentsKoo = new List<VRCourseKoo>();
    public static ContentsType m_ContentsType;
}



public struct VRCourseKoo2
{

    public string course_id { get; set; }
    public string service_title { get; set; }
    public string course_content_id { get; set; }


    public VRCourseKoo2(string courseID, string serviceTitle, string contentsID)
    {
        course_id = courseID;
        service_title = serviceTitle;
        course_content_id = contentsID;


    }
}


public static class VRContentsKoo2
{
    static VRContentsKoo2()
    {
        // Add Contents        
    }

    public static List<VRCourseKoo2> m_VRContentsKoo2 = new List<VRCourseKoo2>();
    public static ContentsType m_ContentsType;
}
