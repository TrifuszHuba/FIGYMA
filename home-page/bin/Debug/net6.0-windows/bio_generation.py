import os
import openai

openai.api_key = open("api_key.txt", "r", encoding="utf-8").read()

description_file = open('personData.txt', 'r')
description = description_file.read().split('\n')

for i in range(5):
    response = openai.Completion.create(
        model="text-davinci-003",
        prompt=f"write a short bio of a single {description[0]} in first person",
        temperature=1,
        max_tokens=256,
        top_p=1,
        frequency_penalty=0,
        presence_penalty=0
    )
    output = str(response['choices'][0]['text']).strip()
    f = open(f"bio{i}.txt", "w")
    f.write(output)