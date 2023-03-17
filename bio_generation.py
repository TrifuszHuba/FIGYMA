import os
import openai

api_key = open("api_key.txt", "r", encoding="utf-8").read()

openai.api_key = os.getenv(api_key)

response = openai.Completion.create(
    model="text-davinci-003",
    prompt="",
    temperature=1,
    max_tokens=256,
    top_p=1,
    frequency_penalty=0,
    presence_penalty=0
)
