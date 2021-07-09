using System.Collections;
using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Test : MonoBehaviour
{
    public string textCursor = "|";
    public int cursorIndex = 0;
    public Text str;
    public int textLength;
    public Button Save;
    public Button Load;
    public Button Create;
    public InputField Name;
    string path;

    private void Start()
    {
        Save.onClick.AddListener(Saving);
        Load.onClick.AddListener(Loading);
        Create.onClick.AddListener(Creating);
        str.text = str.text.Insert(cursorIndex, textCursor);
    }


    void Insert()
    {
        if(!Name.isFocused)
        foreach (char c in Input.inputString)
        {
            {
                str.text= str.text.Insert(cursorIndex ,c.ToString());
                str.text = str.text.Remove(cursorIndex + 1, 1);
                cursorIndex++;
                str.text = str.text.Insert(cursorIndex, textCursor);
            }
        }
    }
    void cursorRighting()
    {
        if (!Name.isFocused)
            if (cursorIndex < str.text.Length - 1)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex++;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
    }

    void cursorLefting()
    {
        if (!Name.isFocused)
            if (cursorIndex != 0)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex--;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
    }
    void cursorDowning()
    {
        if (!Name.isFocused)
            if (cursorIndex + 45 <= textLength)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex = cursorIndex + 45;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
        else End();
    }
    void cursorUping()
    {
        if (!Name.isFocused)
            if (cursorIndex - 45 >= 0)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex = cursorIndex - 45;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
        else Home();
    }

    void Backspace()
    {
        if (!Name.isFocused)
            if (cursorIndex > 1)
        {
            str.text = str.text.Remove(cursorIndex - 2, 1);
            cursorIndex -= 2;
            str.text = str.text.Remove(cursorIndex, 1);
        }
    }

    void Delete()
    {
        if (!Name.isFocused)
            if (cursorIndex< (textLength - 1))
        {
            str.text = str.text.Remove(cursorIndex + 1, 1);
        }
    }
    
    void Home()
    {
        if (!Name.isFocused)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex = 0;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
    }

    void End()
    {
        if (!Name.isFocused)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            cursorIndex = textLength - 1;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
    }
    void Saving()
    {
        if (Name.text != "")
        {
            str.text = str.text.Remove(cursorIndex, 1);
            File.WriteAllText(Name.text+".txt", str.text);
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
        else
        {
            str.text = str.text.Remove(cursorIndex, 1);
            File.WriteAllText("new.txt", str.text);
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
    }
    
    public void Loading()
    {
        path = EditorUtility.OpenFilePanel("", "", "txt");
        if (path.Length != 0)
        {
            str.text = str.text.Remove(cursorIndex, 1);
            str.text = File.ReadAllText(path);
            cursorIndex = 0;
            str.text = str.text.Insert(cursorIndex, textCursor);
        }
        else
        {
            Debug.Log("Path empty");
        }
    }

    void Creating()
    {
        
        if (Name.gameObject.active == true)
        {
            Name.gameObject.active = false;
        }
        else
        {
            Name.gameObject.active = true;
        }
    }

    void Update()
    {
        textLength = str.text.Length;
        Insert();
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cursorRighting();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cursorLefting();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cursorDowning();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cursorUping();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Backspace();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Delete();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            Home();
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            End();
        }
    }
}
