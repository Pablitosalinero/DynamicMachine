# -*- coding: utf-8 -*-

"""
Created on Sat Aug 29 01:48:26 2020
@author: Pablo Salinas Rodriguez
"""

INF = 99999

def change(coins, value, l, ncoins):
    if (value == 0):
        return [0] * ncoins
    if (value < 0):
        return [INF] * ncoins
    if (len(coins) == 1):
        if(value/coins[len(coins)-1] <= l[len(coins)-1]):
            return [int(value/coins[len(coins)-1])] + ([0]*(ncoins-1))
        else:
            return [INF] + ([0]*(ncoins-1))
    res1 = change(coins, value-coins[-1], l, ncoins)
    res1[len(coins)-1] = res1[len(coins)-1] + 1
    res2 = change(coins[:-1], value, l, ncoins)
    res3 = change(coins[:-1], value-(l[len(coins)-1] * coins[-1]), l, ncoins)
    res3[len(coins)-1] = res3[len(coins)-1] + l[len(coins)-1]
        
    if((res1[len(coins)-1]) > l[len(coins)-1]):
        if ((sum(res2)) <= sum(res3)):
            return res2
        else: 
            return res3
    else: 
        if (sum(res1) <= sum(res2)):
            return res1 
        else:
            return res2