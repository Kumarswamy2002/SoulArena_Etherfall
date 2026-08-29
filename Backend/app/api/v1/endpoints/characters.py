from typing import List
from fastapi import APIRouter, HTTPException, status
from pydantic import BaseModel

router = APIRouter(prefix="/characters", tags=["Characters"])

class CharacterRosterItem(BaseModel):
    id: str
    name: str
    title: str
    element: str
    role: str
    weapon: str
    difficulty: str
    description: str

ROSTER_DATA: List[dict] = [
    {"id": "kael_varyn", "name": "Kael Varyn", "title": "Stormbound", "element": "Storm", "role": "Rushdown / Balanced", "weapon": "Twin Ether Blades", "difficulty": "Medium", "description": "Tempestuous warrior wielding dual energized lightning blades."},
    {"id": "ryka_voss", "name": "Ryka Voss", "title": "Ember Wolf", "element": "Ember", "role": "Aggressive Bruiser", "weapon": "Chain Gauntlets", "difficulty": "Easy", "description": "Fierce gladiator striking with blazing chain gauntlets and pack fury."},
    {"id": "seren_vale", "name": "Seren Vale", "title": "Frozen Blade", "element": "Frost", "role": "Control", "weapon": "Crystal Katana", "difficulty": "Hard", "description": "Diamond-forged katana duelist freezing space and opponent frames."},
    {"id": "zayn_rheo", "name": "Zayn Rheo", "title": "Lightning Phantom", "element": "Volt", "role": "Speed / Assassin", "weapon": "Twin Daggers", "difficulty": "Hard", "description": "Hyper-speed rogue moving faster than light with electrocuting decoys."},
    {"id": "drakor_thane", "name": "Drakor Thane", "title": "Iron Colossus", "element": "Stone", "role": "Tank", "weapon": "Massive Hammer", "difficulty": "Easy", "description": "Seismic mountain clad in heavy stone with devastating armored swings."},
    {"id": "vexa_noir", "name": "Vexa Noir", "title": "Void Walker", "element": "Void", "role": "Trickster / Assassin", "weapon": "Void Blades", "difficulty": "Expert", "description": "Null Realm assassin slipping between dimensions to strike from behind."},
    {"id": "elara_sol", "name": "Elara Sol", "title": "Dawn Saint", "element": "Radiance", "role": "Support / Fighter", "weapon": "Light Spear", "difficulty": "Medium", "description": "Solar paladin blinding foes and wielding righteous radiant spears."},
    {"id": "torren_kai", "name": "Torren Kai", "title": "Wind Dancer", "element": "Gale", "role": "Mobility", "weapon": "Twin Rings", "difficulty": "Hard", "description": "Acrobatic wind monk mastering aerial juggles and razor chakrams."},
    {"id": "raven_drake", "name": "Raven Drake", "title": "Blood Knight", "element": "Crimson", "role": "High Risk / Reward", "weapon": "Greatsword", "difficulty": "Medium", "description": "Cursed swordsman trading health for catastrophic crimson cleaves."},
    {"id": "nyla_verd", "name": "Nyla Verd", "title": "Wild Caller", "element": "Nature", "role": "Summoner", "weapon": "Spirit Bow", "difficulty": "Medium", "description": "Forest shaman firing spirit arrows and rooting foes in briars."},
    {"id": "orin_veil", "name": "Orin Veil", "title": "Mind Weaver", "element": "Psionic", "role": "Control", "weapon": "Ether Orbs", "difficulty": "Expert", "description": "Telekinetic scholar controlling psionic spheres that disrupt minds."},
    {"id": "solan_ark", "name": "Solan Ark", "title": "Sunforged", "element": "Solar", "role": "Power Fighter", "weapon": "Ether Fists", "difficulty": "Medium", "description": "Martial master channeling miniature solar flares into bare knuckles."},
    {"id": "mira_tide", "name": "Mira Tide", "title": "Tideblade", "element": "Tidal", "role": "Balanced", "weapon": "Water Blades", "difficulty": "Medium", "description": "Fluid duelist shifting seamlessly between tidal waves and ripostes."},
    {"id": "kade_rourke", "name": "Kade Rourke", "title": "Iron Marauder", "element": "Metal", "role": "Brawler", "weapon": "Mechanical Gauntlets", "difficulty": "Easy", "description": "Rugged mechanist outfitted with steam-pressured hydraulic gauntlets."},
    {"id": "aeris_quin", "name": "Aeris Quin", "title": "Star Weaver", "element": "Astral", "role": "Ranged", "weapon": "Ether Staff", "difficulty": "Hard", "description": "Astronomer mystic weaving zodiac constellations into meteor storms."},
    {"id": "rokan_fen", "name": "Rokan Fen", "title": "Beast Soul", "element": "Beast", "role": "Close Combat", "weapon": "Clawed Gauntlets", "difficulty": "Easy", "description": "Feral brawler fusing his soul with apex predators for vicious rends."},
    {"id": "nox_arden", "name": "Nox Arden", "title": "Riftborn", "element": "Rift", "role": "Space Manipulator", "weapon": "Rift Scythe", "difficulty": "Expert", "description": "Spatial reaper cutting reality tears and swapping positions in combat."},
    {"id": "yuna_rei", "name": "Yuna Rei", "title": "Spirit Dancer", "element": "Spirit", "role": "Technical Fighter", "weapon": "Ribbon Blades", "difficulty": "Expert", "description": "Shrine maiden blending sacred ribbon dances with edge precision."},
    {"id": "morvan_kreel", "name": "Morvan Kreel", "title": "Grave King", "element": "Death", "role": "Summoner / Control", "weapon": "Soul Staff", "difficulty": "Hard", "description": "Necromantic sovereign draining Ether to summon skeletal armies."},
    {"id": "auren_zeth", "name": "Auren Zeth", "title": "First Soul", "element": "Prime Ether", "role": "Boss / Advanced", "weapon": "Ether Greatblade", "difficulty": "Master", "description": "Primordial creator wielding mastery over all elements and the universe."}
]

@router.get("", response_model=List[CharacterRosterItem])
async def list_characters():
    return ROSTER_DATA

@router.get("/{character_id}", response_model=CharacterRosterItem)
async def get_character_detail(character_id: str):
    for char in ROSTER_DATA:
        if char["id"] == character_id:
            return char
    raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Character '{character_id}' not found.")
