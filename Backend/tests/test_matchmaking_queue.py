from Backend.pvp.matchmaking_queue import ArenaMatchmakingQueue

def test_elo_calculation():
    gain = ArenaMatchmakingQueue.calculate_elo_change(1500, 1500)
    assert gain == 16
