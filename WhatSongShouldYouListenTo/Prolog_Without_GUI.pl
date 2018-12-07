intro:-
	write('what song should you listen to right now?'), nl,
	write('To answer, input the number shown next to each answer, followed by a dot (.)'), nl, nl.
	
find_song(baiHat):-
	song(baiHat), !.

	
/*list bai hat dem

cry_over_you


*/
%mieu ta bai hat
describe(cry_over_you):-
	write('Cry over you - JustaTee, Binz'), nl,
	write('https://www.youtube.com/watch?v=BhI0XegF7o4'), n1.

	
describe(die_a_happy_man):-
	write('Die a happy man - Thomas Rhett'), nl,
	write('https://www.youtube.com/watch?v=UZmj8rrk6bg'), nl.

describe(shots):-
	write('Shots (Broiler Remix) - Imagine Dragons'), nl,
	write('https://www.youtube.com/watch?v=UcHJtgljXEo'), nl.
	
describe(love_me_tender):-
	write('Love me tender - Piano'), nl,
	write('https://www.youtube.com/watch?v=TepTGONg0yE'), nl.

describe(nhin_vao_mua):-
	write('Nhin vao mua (Em gai mua OST) - Trung Quan Idol'), nl,
	write('https://www.youtube.com/watch?v=ltAnEOtGajs'), nl.
		
describe(va_toi_hat):-
	write('Va toi hat - Monstar'), nl,
	write('https://www.youtube.com/watch?v=DHnbkEMg15s'), nl.

describe(heres_to_never_growing_up):-
	write('Heres to never growing up - Avril Lavigne'), nl,
	write('https://www.youtube.com/watch?v=sXd2WxoOP5g'), nl.
	
describe(something_just_like_this):-
	write('The Chainsmokers & Coldplay - Something Just Like This (Lyric)'), nl,
	write('https://www.youtube.com/watch?v=FM7MFYoylVs'), nl.

describe(come_in_with_the_rain):-
	write('Come in with the rain -  Taylor Swift'), nl,
	write('https://www.youtube.com/watch?v=qxW5ZS8UgJc'), nl.

describe(when_the_love_falls):-
	write('When the love falls (Piano) - Yiruma'), nl,
	write('https://www.youtube.com/watch?v=rDzDvP0dEBU'), nl.

describe(rain):-
	write('S1LVA - Rain (Feat. Alina Renae)'), nl,
	write('https://www.youtube.com/watch?v=lE_B8DteIyk'), nl.

	
%question
question(how_tam_trang):-
	write('How do you feel?'), nl.

question(which_language):-
	write('Which country would you like?'), nl.

	
%rules
song(cry_over_you):-
	how_tam_trang(bored).

song(cry_over_you):-
	how_tam_trang(i_dont_know).

song(when_the_love_falls):-
	how_tam_trang(rainning),
	which_language(us),
	what_the_loai(khong_loi).
	
song(nhin_vao_mua):-
	how_tam_trang(rainning),
	which_language(vietnam),
	what_the_loai(nhac_pop).

song(come_in_with_the_rain):-
	how_tam_trang(rainning),
	which_language(us),
	what_the_loai(nhac_pop).

song(come_in_with_the_rain):-
	how_tam_trang(rainning),
	which_language(us),
	what_the_loai(country).

song(rain):-
	how_tam_trang(rainning),
	which_language(us),
	what_the_loai(edm).	

song(die_a_happy_man):-
	how_tam_trang(thu_gian),
	which_language(us),
	what_the_loai(country).

song(shots):-
	how_tam_trang(thu_gian),
	which_language(us),
	what_the_loai(edm).

song(love_me_tender):-
	how_tam_trang(thu_gian),
	which_language(us),
	what_the_loai(khong_loi).

song(nhin_vao_mua):-
	how_tam_trang(thu_gian),
	which_language(vn),
	what_the_loai(nhac_pop).

song(va_toi_hat):-
	how_tam_trang(dong_luc),
	which_language(vietnam),
	what_the_loai(nhac_pop).

song(heres_to_never_growing_up):-
	how_tam_trang(dong_luc),
	which_language(us),
	what_the_loai(nhac_pop).

song(heres_to_never_growing_up):-
	how_tam_trang(dong_luc),
	which_language(us),
	what_the_loai(country).

song(when_the_love_falls):-
	how_tam_trang(dong_luc),
	which_language(us),
	what_the_loai(khong_loi).

song(something_just_like_this):-
	how_tam_trang(dong_luc),
	which_language(us),
	what_the_loai(edm).

	
	