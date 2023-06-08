names = []
user_input = nil

while user_input != '' do
    user_input = gets.encode('UTF-8').chomp
    names << user_input
end

for name in names do
    puts "С нами #{name}"
    sleep 1

    if (name == 'Элис')
        puts "Элис? Кто такая Элис?"
        sleep 1
        break
    end
end 