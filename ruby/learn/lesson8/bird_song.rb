arguments = ARGV[0]

season = 0
temp = 0

if (ARGV[0] != nil)
    season = ARGV[0].to_i
    temp = ARGV[1].to_i
else
    puts "Какое время года? (0 - весна, 1 - лето, 2 - осень, 3 - зима): "
    season = STDIN.gets.chomp.to_i
    puts "Сколько сейчас градусов (С): "
    temp = STDIN.gets.chomp.to_i
end

# Определение времени года
if ((season == 1 && (temp> 15 && temp < 35)) || (season != 1 && (temp > 22 && temp < 30)))
    puts "Соловьи поют."
else
    puts "Соловьи не поют."
end
