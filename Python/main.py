# -*- coding: utf-8 -*-
"""
Created on Sun Aug 30 02:20:23 2020

@author: Pablo Salinas Rodríguez
"""
import dynamicmachine as dm

c = [  1, 2, 5, 10, 20, 50] 
l = [4050, 2, 1, 1, 1, 4]
errors = 0
value = 227

res = dm.change(c, value, l, len(c))
print("Money types: "+str(c))
print("Money types limits: "+str(l))
print("Expected value: "+str(value)+"€")
print("Result: "+str(res)+ " -> "+str(sum(res))+ " count coins")
print("Result value: "+str(sum([x*y for x,y in list(zip(res, c))]))+"€")
