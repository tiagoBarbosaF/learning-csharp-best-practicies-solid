﻿using System;
using System.Collections.Generic;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Services.Interfaces;

namespace LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private ILeilaoDao _leilaoDao;

        public DefaultAdminService(ILeilaoDao leilaoDao)
        {
            _leilaoDao = leilaoDao;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _leilaoDao.GetCategorias();
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            return _leilaoDao.GetLeiloes();
        }

        public Leilao GetLeilaoById(int id)
        {
            return _leilaoDao.GetById(id);
        }

        public void RecordLeilao(Leilao leilao)
        {
            _leilaoDao.Record(leilao);
        }

        public void UpdateLeilao(Leilao leilao)
        {
            _leilaoDao.Update(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _leilaoDao.Remove(leilao);
            }
        }

        public void InitiatePregaoWithId(int id)
        {
            var leilao = _leilaoDao.GetById(id);

            if (!(leilao is { Situacao: SituacaoLeilao.Rascunho })) return;
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _leilaoDao.Update(leilao);
        }

        public void FinishPregaoWithId(int id)
        {
            var leilao = _leilaoDao.GetById(id);

            if (leilao == null || leilao.Situacao != SituacaoLeilao.Pregao) return;
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _leilaoDao.Update(leilao);
        }
    }
}