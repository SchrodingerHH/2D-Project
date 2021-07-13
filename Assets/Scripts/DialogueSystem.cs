using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("dialogue")]
public class DialogueSystem
{
    [XmlElement("node")]
    public Node[] nodes;


    public static DialogueSystem GetDialogue(TextAsset xmlDialogue)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(DialogueSystem));
        StringReader stringR = new StringReader(xmlDialogue.text);
        DialogueSystem result = xmlSer.Deserialize(stringR) as DialogueSystem;

        return result;
    }

}

public class Node
{
    [XmlArray("answers"),XmlArrayItem("answer")]
    public Answers[] answers;
    
    [XmlElement("endnode")]
    public string endnode;
    
    [XmlElement("text")]
    public string text;
}

public class Answers 
{
    [XmlElement("answertext")]
    public string answerText;

    [XmlAttribute("tonode")]
    public int toNode;

}