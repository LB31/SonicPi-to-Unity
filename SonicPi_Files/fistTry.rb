# Welcome to Sonic Pi v3.1

live_loop :guit do
  with_fx :echo, mix: 0.3, phase: 0.25 do
    sample :guit_em9, rate: 0.5
    use_osc"127.0.0.1", 9000
    osc"/unity/note", "hi man"
  end
  #  sample :guit_em9, rate: -0.5
  sleep 8
end
live_loop :boom do
  with_fx :reverb, room: 1 do
    sample :bd_boom, amp: 10, rate: 1
  end
  sleep 8
  
  
end

