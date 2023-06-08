# .................................
puts "Цикл while"

count = 1

while count <= 5 do
    puts count
    count += 1
    sleep 0.5
end

puts "Отсчет закончен"
# .................................
puts "Цикл for"

# Массив яиц, 0 - целов, другое значение - битое
eggs = [0, 0, 0, 0, 1, 1, 0, 0, 1, 23, 0, 2, 0, 25, 0, 0, 1, 0]

good_eggs = []
broken_count = 0

for egg in eggs do
    if (egg != 0)
        broken_count += 1
    else
        good_eggs << egg
    end 
end

puts "Первоначальный массив яиц: #{eggs.to_s}"
puts "Целые яица: #{good_eggs.to_s} (#{good_eggs.count} шт.)"
puts "Количество разбитых яиц: #{broken_count}"