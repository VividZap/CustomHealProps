using System.Collections.Generic;
using System.ComponentModel;
using CustomHealprops.Item;
using Exiled.API.Interfaces;

namespace CustomHealprops
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        public bool Debug { get; set; } =  false;
        /// <summary>
        /// You can edit hints here in Config for all items in this Poject just change it
        /// for color: <color=#Codecolor> bla bla bla </color>
        /// </summary>
        [Description("Hint Items settings")]
        public string DrugHint { get; set; } = "";
        public string FakeSCP500Hint {get; set;} = "";
        public string EnhancedSCP500Hint { get; set; } = "";
        public string AdrenalineIHint { get; set; } = "";
        public string AdrenalineIIHint { get; set; } = "";
        /// <summary>
        /// For work register Items In game
        /// </summary>
        [Description("Register CustomItems")]
        public Drugs Drugs { get; set; } = new Drugs();
        public List<Drugs> DrugsList { get; set; } = new List<Drugs>();
        
        public EnhancedSCP500 EnhancedSCP500 { get; set; } = new EnhancedSCP500();
        public List<EnhancedSCP500> EnhancedScp500s { get; set; } = new List<EnhancedSCP500>();
        
        public FakeSCP500 FakeScp500 {get; set;} = new FakeSCP500();
        public List<FakeSCP500> FakeScp500List { get; set; } = new List<FakeSCP500>();
        
        public AdrenalineI adrenalineI { get; set; } = new AdrenalineI();
        public List<AdrenalineI> AdrenalineIList { get; set; } = new List<AdrenalineI>();
        
        public AdrenalineII adrenalineII { get; set; } = new AdrenalineII();
        public List<AdrenalineII> AdrenalineIIList { get; set; } = new List<AdrenalineII>();
    }
}