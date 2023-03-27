using IMR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class CourseLessonManager : Lesson
{
    List<Dictionary<string, string>> resultStatement;

    InitalizeStatement initStatement;
    ChoiceStatement choiceStatement;
    TerminateStatement terminateStatement;

    public CourseLessonManager(string name, string nameEng)
    {
        lessonName = name;
        lessonNameEng = nameEng;
        Init();
    }

    public sealed override void Init()
    {
        statement_dictionary = new Dictionary<string, IMRStatement>();
        resultStatement = new List<Dictionary<string, string>>();

        initStatement = new InitalizeStatement();
        choiceStatement = new ChoiceStatement();
        terminateStatement = new TerminateStatement();

        SetObject();

        statement_dictionary.Add("Init", initStatement);
        statement_dictionary.Add("Choice", choiceStatement);
        statement_dictionary.Add("Terminate", terminateStatement);
    }

    public void SetObject()
    {
        initStatement.SetActivity(COURSE_NAME + "/" + lessonName);
        choiceStatement.SetActivity(COURSE_NAME + "/" + lessonName + "/selection");
        terminateStatement.SetActivity(COURSE_NAME + "/" + lessonName);
        
        terminateStatement.SetResultExtensionFromResultStatements(resultStatement, lessonName);

        initStatement.SetContextExtensionLesson(lessonName);
        choiceStatement.SetContextExtensionLesson(lessonName);
        terminateStatement.SetContextExtensionLesson(lessonName);

        terminateStatement.SetSuccess(_completion);
        terminateStatement.SetScore(_score);
    }

    public sealed override void ChangeNewStatement(string name)
    {
        switch(name)
        {
            case "Init":
                initStatement = new InitalizeStatement();
                statement_dictionary[name] = initStatement;
                SetObject();
                break;
            case "Choice":
                choiceStatement = new ChoiceStatement();
                statement_dictionary[name] = choiceStatement;
                SetObject();
                break;
            case "Terminate":
                terminateStatement = new TerminateStatement();
                statement_dictionary[name] = terminateStatement;
                SetObject();
                terminateStatement.SetResultExtensionFromResultStatements(resultStatement, lessonName);
                break;
        }
    }

    public sealed override void UpdateResultStatement(int score, bool complete)
    {
        resultStatement.Clear();

        //추가 내용 전부 삭제
        //foreach(var v in results)
        //{
        //    resultStatement.Add(v);
        //}

        _score = score;
        _completion = complete;
    }
    //(생략), total score, true(중간에 나가면 false, 정상종료 하면 true)

    public sealed override void UpdateChoice(string item, string step, bool success)
    {
        JObject resultExtension = new JObject();
        JProperty eItem = new JProperty("evaluation-item", item);
        JProperty eStep = new JProperty("evaluation-step", step);

        JObject tempProperty = new JObject(eItem, eStep);
        resultExtension.Add(Lesson.BASE_URL + "/extension/selection", tempProperty);
        choiceStatement.SetResultExtensions(resultExtension);
        choiceStatement.SetSuccess(success);
    }
    //1, 이론_xxxx, true or false 
}