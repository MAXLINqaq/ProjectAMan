using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AM.UI
{
    [CreateAssetMenu(menuName = "AM/PaperConfig")]
    public class PaperConfig : ScriptableObject
    {
        [SerializeField]
        List<PaperArticle> papers = new List<PaperArticle>();
        [System.Serializable]
        public class PaperArticle{
            public int id;
            public string content;
        }
        Dictionary<int, PaperArticle> dict;
        public void Init(){
            dict = new Dictionary<int, PaperArticle>();
            foreach(var paper in papers){
                dict.Add(paper.id, paper);
            }
        }
        public string GetPaperContent(int id){
            return dict[id].content;
        }
    }
}