import os
import openai

openai.api_key = open("api_key.txt", "r", encoding="utf-8").read()

response = openai.Completion.create(
    model="text-davinci-003",
    prompt="write a short bio of a single man in first person",
    temperature=1,
    max_tokens=256,
    top_p=1,
    frequency_penalty=0,
    presence_penalty=0
)

print(response['choices'][0]['text'])
